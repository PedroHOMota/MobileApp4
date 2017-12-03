﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver, restart;
    private int score=0;

    void Start ()
    {
        StartCoroutine(SpawnWaves());
        UpdateScore(0);

        gameOver = restart = false;

    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }

    public void EndGame()
    {
        Debug.Log("Entrou");
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
                Application.LoadLevel(Application.loadedLevel);
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(1);
        while (gameOver==false) //Making waves
        {
            for (int i = 0; i< spawnCount; i++)
            {
                Vector3 spawnP = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
                Quaternion spawnR = Quaternion.identity;
                Instantiate(hazard, spawnP, spawnR);
                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver)
            {
                restart = true;
                restartText.text = "Press P to restart";
            }
            yield return new WaitForSeconds(2);
        }
    }
}
