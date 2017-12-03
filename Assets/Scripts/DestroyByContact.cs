using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;

    int score;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent <GameController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.EndGame();
        }
        gameController.UpdateScore(10);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
