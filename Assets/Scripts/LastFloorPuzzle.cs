using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastFloorPuzzle : MonoBehaviour
{
    public static LastFloorPuzzle lastFloorPuzzleInstance;

    public bool firstBrazier = true;
    public bool secondBrazier = false;
    public bool thirdBrazier = false;
    public bool fourthBrazier = false;
    public bool fifthBrazier = false;
    public bool sixthBrazier = false;

    public int counter = 0;

    private void Awake()
    {
        if (lastFloorPuzzleInstance == null)
        {
            lastFloorPuzzleInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(counter == 6)
        {
            //make the GameOver UI appear
        }
    }
}
