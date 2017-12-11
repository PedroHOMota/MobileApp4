using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	private AudioSource audioSource;
	public float fireRate;
	public float delay; //Controls when the enemy ships stars firing
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();	
		InvokeRepeating ("Fire",delay,fireRate);
	}

	void Fire()
	{
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		audioSource.Play ();
	}

}
