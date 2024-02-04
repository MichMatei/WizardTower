using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuzzle : MonoBehaviour
{
    public GameObject doorToBeOpened;
    public GameObject firstBrazier;
    public GameObject secondBrazier;
    public GameObject thirdBrazier;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstBrazier.SetActive(false);
        secondBrazier.SetActive(false);
        thirdBrazier.SetActive(false);
    }

    private void OnEnable()
    {
        if (firstBrazier.activeSelf)
        {
            counter++;
        }
    }
}
