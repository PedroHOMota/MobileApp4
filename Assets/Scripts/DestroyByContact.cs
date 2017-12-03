using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;

        Instantiate(explosion, transform.position, transform.rotation);

        //GetComponent<AudioSource>().Play();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
