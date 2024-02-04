using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public static MagicScript magicScriptInstance;

    public GameObject movingPage;
    public GameObject movingPageSide1;
    public GameObject movingPageSide2;

    public GameObject leftPage;
    public GameObject leftPageChild;

    public GameObject rightPage;
    public GameObject rightPageChild;

    public bool learnedLevitateSpell = false;
    public bool learnedFreezeSpell = false;
    public bool learnedFireSpell = false;

    public bool levitating = false;
    public float levitateDuration = 0f;

    public bool canFreeze = false;
    public bool canBurn = false;
    public bool canLevitate = false;

    bool canMove = false;
    bool canSwitchPage = true;

    bool levitatePage = false;
    bool freezePage = false;
    bool firePage = false;

    int previousPage = -1;

    public Material[] materials;


    private void Awake()
    {
        if (magicScriptInstance == null)
        { 
            magicScriptInstance = this;
        } 
        else 
        { 
            Destroy(this);
            Debug.Log("Instance was NOT null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        movingPage.GetComponent<MeshRenderer>().enabled = false;
        movingPageSide1.GetComponent<MeshRenderer>().enabled = false;
        movingPageSide2.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLevitate && Input.GetKey(KeyCode.E))
        {
            //levitate
            //go to PlayerMovement.cs line 37
            levitating = true;
            PlayerMovement.playerMovementInstance.velocity = Vector3.zero;
            canLevitate = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!canSwitchPage)
            {
                return;
            }

            if ((Input.GetKeyDown(KeyCode.Alpha1) && !learnedLevitateSpell) || (Input.GetKeyDown(KeyCode.Alpha2) && !learnedFreezeSpell) || (Input.GetKeyDown(KeyCode.Alpha3) && !learnedFireSpell))
            {
                return;
            }

            canMove = true;
            canSwitchPage = false;

            //checks which page was the last page and loads the correct mesh on the left side of the moving page
            if (previousPage == 0)
            {
                movingPageSide1.GetComponent<MeshRenderer>().material = materials[0];
            }
            else if (previousPage == 1)
            {
                movingPageSide1.GetComponent<MeshRenderer>().material = materials[1];
            }
            else if (previousPage == 2)
            {
                movingPageSide1.GetComponent<MeshRenderer>().material = materials[2];
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && learnedLevitateSpell)
            {
                levitatePage = true;
                canLevitate = true;

                canFreeze = false;
                canBurn = false;

                movingPage.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide1.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide2.GetComponent<MeshRenderer>().enabled = true;

                movingPageSide2.GetComponent<MeshRenderer>().material = materials[0];
                rightPageChild.GetComponent<MeshRenderer>().material = materials[0];
                
                previousPage = 0;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2) && learnedFreezeSpell)
            {
                freezePage = true;
                canFreeze = true;

                canLevitate = false;
                canBurn = false;

                movingPage.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide1.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide2.GetComponent<MeshRenderer>().enabled = true;

                movingPageSide2.GetComponent<MeshRenderer>().material = materials[1];
                rightPageChild.GetComponent<MeshRenderer>().material = materials[1];

                previousPage = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && learnedFireSpell)
            {
                firePage = true;
                canBurn = true;

                canFreeze = false;
                canLevitate = false;

                movingPage.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide1.GetComponent<MeshRenderer>().enabled = true;
                movingPageSide2.GetComponent<MeshRenderer>().enabled = true;

                movingPageSide2.GetComponent<MeshRenderer>().material = materials[2];
                rightPageChild.GetComponent<MeshRenderer>().material = materials[2];

                previousPage = 2;
            }
        }
    }

    //turning the page
    private void FixedUpdate()
    {
        if (movingPage.transform.localRotation == Quaternion.Euler(-45, 0, 0))
        {
            canMove = false;

            movingPage.GetComponent<MeshRenderer>().enabled = false;
            movingPageSide1.GetComponent<MeshRenderer>().enabled = false;
            movingPageSide2.GetComponent<MeshRenderer>().enabled = false;

            canSwitchPage = true;
        }

        if (canMove)
        {
            movingPage.transform.localRotation *= Quaternion.Lerp(movingPage.transform.localRotation, Quaternion.Euler(-1f, 0f, 0f), 50 * Time.fixedDeltaTime);
        }

        if (!canMove)
        {
            movingPage.transform.localRotation = Quaternion.Euler(45f,0f,0f);

            if (levitatePage == true)
            {
                leftPageChild.GetComponent<MeshRenderer>().material = materials[0];
            }
            else if (freezePage == true)
            {
                leftPageChild.GetComponent<MeshRenderer>().material = materials[1];
            }
            else if (firePage == true)
            {
                leftPageChild.GetComponent<MeshRenderer>().material = materials[2];
            }

            levitatePage = false;
            freezePage = false;
            firePage = false;
        }
    }
}
