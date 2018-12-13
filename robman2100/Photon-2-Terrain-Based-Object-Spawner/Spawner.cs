using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //Created by Robert Moses (robman2100)- 12-13-2018
 //This Script will spawn an object randomly based on terrain coordinates. 
 //It finds the size, and height and translates that to a position to spawn an object. Enjoy!
 //Sincerely,
 //Robert
public class Spawner : MonoBehaviour {
   public GameObject enemies;
    public GameObject enemies1;
    public GameObject enemies2;
    public Terrain terrain;
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z
    // Use this for initialization
    void Start () {
       
            // terrain size x
            terrainWidth = (int)terrain.terrainData.size.x;
            // terrain size z
            terrainLength = (int)terrain.terrainData.size.z;
            // terrain x position
            terrainPosX = (int)terrain.transform.position.x;
            // terrain z position
            terrainPosZ = (int)terrain.transform.position.z;      
           
        //Lets check to make sure we have our Terrain Positions
        Debug.Log("Terrain X " + terrainPosX);
        Debug.Log("Terrain Z " + terrainPosZ);
    }
 
   
    // Update is called once per frame
    void Update()
    {
       
            // generate objects
            if (currentObjects <= numberOfObjects)
            {
                // generate random x position
                int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                // generate random z position
                int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                // get the terrain height at the random position
                float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            // create new gameObject on random position            
            enemies = PhotonNetwork.InstantiateSceneObject("smallPower", new Vector3(posx, posy, posz), Quaternion.identity, 0, null) as GameObject;
            currentObjects += 1;
            }
            if (currentObjects == numberOfObjects)
            {
                Debug.Log("Generated or Respawned objects !");
            }
        }
