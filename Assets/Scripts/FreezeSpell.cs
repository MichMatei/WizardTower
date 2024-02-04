using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpell : MonoBehaviour
{

    public GameObject waterCube;
    bool canBeFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        TurnOffAllCubes();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canBeFrozen)
        {
            TurnOnAllCubes();
        }

        if(Input.GetKey(KeyCode.E) && canBeFrozen)
        {
            if (waterCube.transform.localScale.x > 5f)
            {
                Debug.Log("returned");
                return;
            }

            waterCube.transform.localScale += Vector3.one * 0.01f;
            Debug.Log("DIDN'T return");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canBeFrozen = true;
    }

    private void ontriggerExit(Collider other)
    {
        canBeFrozen = false;
    }

    void TurnOffAllCubes()
    {
        waterCube.SetActive(false);

    }

    void TurnOnAllCubes()
    {
        waterCube.SetActive(true);
    }
}
