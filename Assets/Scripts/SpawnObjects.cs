using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public static SpawnObjects instance;
    int currentScore;
    public Terrain terrain;
    public int numberOfObjects; // number of objects to place
    [HideInInspector]
    public int currentObjects; // number of placed objects
    public GameObject[] objectToPlace; // GameObject to place
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;

    }


    private void Update()
    {

        if (currentObjects <= numberOfObjects)
        {
            int randomNum = Random.Range(0, 2);
            PlaceObject(randomNum);
            currentObjects += 1;
        }
        if (currentObjects == numberOfObjects)
        {
            Debug.Log("Generate objects complete!");
        }
    }
    public void PlaceObject(int randomNum)
    {
        // generate random x position
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        // generate random z position
        int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        // get the terrain height at the random position
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
        // create new gameObject on random position
        GameObject newObject = Instantiate(objectToPlace[randomNum], new Vector3(posx, posy, posz), Quaternion.identity);
        Vector3 pos = newObject.transform.position;
        newObject.transform.parent = transform;
        newObject.transform.position = pos;
    }


} // class
