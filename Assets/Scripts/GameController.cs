using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject hazard;
                                     
    void Start ()
    {
        while(true)
            SpawnWaves();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWaves()
    {
        Vector3 spawnP = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),0, spawnValues.z);
        Quaternion spawnR = Quaternion.identity;
        //Debug.Log(spawnR);
        //Debug.Log(spawnP);
        Instantiate(hazard, spawnP, spawnR);
    }
}
