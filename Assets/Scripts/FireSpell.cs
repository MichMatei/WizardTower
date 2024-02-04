using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    MagicScript magicScript;
    public GameObject fireEffect;
    bool canLitUp = false;

    void Start()
    {
        fireEffect.SetActive(false);
        magicScript = MagicScript.magicScriptInstance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canLitUp && magicScript.learnedFireSpell && magicScript.canBurn && fireEffect.activeSelf == false)
        {
            fireEffect.SetActive(true);
            SecondFirePuzzle.counter++;
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
