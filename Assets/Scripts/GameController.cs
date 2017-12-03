using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    void Start ()
    {
        StartCoroutine(SpawnWaves());	
	}
	
	

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(1);
        while (true) //Making waves
        {
            for (int i = 0; i< spawnCount; i++)
            {
                Vector3 spawnP = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
                Quaternion spawnR = Quaternion.identity;
                //Debug.Log(spawnR);
                //Debug.Log(spawnP);
                Instantiate(hazard, spawnP, spawnR);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(2);
        }
    }
}
