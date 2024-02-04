using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFirePuzzle : MonoBehaviour
{
    MagicScript magicScript;

    bool canLitUp = false;

    public GameObject fireEffect;
    public GameObject stairs1;
    public GameObject stairs2;

    private void Awake()
    {
        magicScript = MagicScript.magicScriptInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireEffect.SetActive(false);
        stairs1.SetActive(false);
        stairs2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canLitUp && magicScript.learnedFireSpell && magicScript.canBurn)
        {
            fireEffect.SetActive(true);
            stairs1.SetActive(true);
            stairs2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canLitUp = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canLitUp = false;
    }
}
