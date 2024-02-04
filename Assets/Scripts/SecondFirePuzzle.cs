using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFirePuzzle : MonoBehaviour
{
    public GameObject doorToBeOpened;

    Vector3 firstPosition;
    Vector3 secondPosition;
    Vector3 thirdPosition;

    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = doorToBeOpened.transform.position + Vector3.up * 0.8f;
        secondPosition = doorToBeOpened.transform.position + Vector3.up * 1.6f;
        thirdPosition = doorToBeOpened.transform.position + Vector3.up * 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 1)
        {
            doorToBeOpened.transform.position = Vector3.Lerp(doorToBeOpened.transform.position, firstPosition, 0.5f * Time.deltaTime);
        }
        else if (counter == 2)
        {
            doorToBeOpened.transform.position = Vector3.Lerp(doorToBeOpened.transform.position, secondPosition, 0.5f * Time.deltaTime);
        }
        else if (counter == 3)
        {
            doorToBeOpened.transform.position = Vector3.Lerp(doorToBeOpened.transform.position, thirdPosition, 0.5f * Time.deltaTime);
        }
    }
}
