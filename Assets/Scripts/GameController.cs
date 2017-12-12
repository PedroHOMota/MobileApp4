using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject[] hazards;
    public int spawnCount;
    public float spawnWait;

    public GUIText scoreText;

    private bool gameOver, restart;
	private int lowerBound, upperBound; // used to control which hazards will be spawned
    void Start ()
    {
        StartCoroutine(SpawnWaves());
        UpdateScore(0);
		lowerBound = 0;
		upperBound = hazards.Length - 2; //limit to spawn only asteroids at first 
        gameOver = false;

    }

    public void UpdateScore(int newScore)
    {
		ScoreClass.score += newScore;
		scoreText.text = "Score: " + ScoreClass.score;
    }

    public void EndGame()
    {
        gameOver = true;
    }

    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(2); //Wait for 2 seconds before starting spawning enemies
                                            // So the player will have time to settle 
		while (!gameOver) { //Making waves
			for (int i = 0; i < spawnCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnP = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0, spawnValues.z); //Generates a random spawnpoint inside game area
				Quaternion spawnR = Quaternion.identity;
				Instantiate (hazard, spawnP, spawnR);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (1);
			if (gameOver) {
				SceneManager.LoadScene (2);
			}
		}
    }
}
