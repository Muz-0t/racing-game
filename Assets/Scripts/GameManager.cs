using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    public GameObject Road;
    public GameObject Fuel;
    private GameObject spawnedObject;
    
    private int mapMove;
    private bool fuelEnable = true;
    
    Vector3 startPosition;
    Vector3[] fuelPosition = new Vector3[3]
    {
        new Vector3(-3f,0.5f,12f),
        new Vector3(0f, 0.5f, 12f),
        new Vector3(3f, 0.5f, 12f)
    };

    private void Start()
    {
        startPosition = Road.transform.position;
    }

    private void Update()
    {
        MapMove();
    }

    private void MapMove()
    {
        Road.transform.Translate((Vector3.back * Time.deltaTime) * 5.0f);
        if (Road.transform.position.z <= -15f)
        {
            Road.transform.position = new Vector3(startPosition.z, startPosition.y, 15);

            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }
            
            GenFuel();
        }
    }
    private void GenFuel()
    {
        int random = Random.Range(0,fuelPosition.Length);

        if (fuelEnable == true)
        {
            spawnedObject = Instantiate(Fuel, fuelPosition[random], Quaternion.identity);
            spawnedObject.transform.parent = Road.transform;
            fuelEnable = false;
        }

        fuelEnable = true;
    }
}
