using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLearning : MonoBehaviour
{
    MagicScript magicScript;

    public GameObject levitatePage;

    bool canLearnLevitateSpell;
    bool canLearnFreezeSpell;
    bool canLearnFireSpell;

    // Start is called before the first frame update
    void Start()
    {
        magicScript = MagicScript.magicScriptInstance;
    }

    // Update is called once per frame
    void Update()
    {
        //when the player entered a certain collider, he can press F to learn the spell
        if (canLearnLevitateSpell)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                magicScript.learnedLevitateSpell = true;
                Debug.Log("levitate learned");
            }
        }
        else if (canLearnFreezeSpell)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                magicScript.learnedFreezeSpell = true;
            }
        }
        else if (canLearnFireSpell)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                magicScript.learnedFireSpell = true;
            }
        }
    }

    //the learned spell depends on what tag the collider has.
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "myLevitateTag")
        {  
            canLearnLevitateSpell = true;
        }
        else if (this.gameObject.tag == "myWaterTag")
        {
            canLearnFreezeSpell = true;
        }
        else if (this.gameObject.tag == "myFireTag")
        {
            canLearnFireSpell = true;
        }
    }

    //resetting the ability to learn any spell if the player exits the collider
    private void OnTriggerExit(Collider other)
    {
        canLearnLevitateSpell = false;
        canLearnFreezeSpell = false;
        canLearnFireSpell = false;
    }
}
