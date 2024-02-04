using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFireOn2 : MonoBehaviour
{
    MagicScript magicScript;
    LastFloorPuzzle lastFloorPuzzle;
    public GameObject fireEffect;
    bool canLitUp = false;

    // Start is called before the first frame update
    void Start()
    {
        fireEffect.SetActive(false);
        magicScript = MagicScript.magicScriptInstance;
        lastFloorPuzzle = LastFloorPuzzle.lastFloorPuzzleInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lastFloorPuzzle.thirdBrazier && canLitUp && magicScript.canBurn && magicScript.learnedFireSpell)
        {
            fireEffect.SetActive(true);
            lastFloorPuzzle.counter++;
            lastFloorPuzzle.thirdBrazier = false;
            lastFloorPuzzle.fourthBrazier = true;
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
