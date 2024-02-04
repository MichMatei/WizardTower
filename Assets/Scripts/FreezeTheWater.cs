using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTheWater : MonoBehaviour
{
    ObjectPooler objectPooler;
    PlayerMovement playerMovement;
    MagicScript magicScript;

    public Camera fpsCamera;
    public Vector3 rayHitLocation;

    bool correctLayerWaterHit = false;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        playerMovement = PlayerMovement.playerMovementInstance;
        magicScript = MagicScript.magicScriptInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && magicScript.learnedFreezeSpell && magicScript.canFreeze)
        {
            ShootRay();
            if(!correctLayerWaterHit)
            {
                return;
            }

            objectPooler.SpawnFromPool("Cube", rayHitLocation, playerMovement.transform.rotation);
        }
    }

    //Raycasting for freezing the water
    public void ShootRay()
    {
        Vector3 location;
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MyWater"))
            {
                Debug.Log(hit.transform.name);
                location = hit.transform.position;
                rayHitLocation = hit.point;
                correctLayerWaterHit = true;
            }
            else
            {
                correctLayerWaterHit = false;
            }
        }
    }
}
