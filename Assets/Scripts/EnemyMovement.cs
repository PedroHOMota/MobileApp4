using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
	private Transform target;
    public float speed;
	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	void Update() 
	{
		if (target == null) //If there is no object to move, just return
			return;

		if (target.position.z > transform.position.z)
			return;
		
        float step = speed * Time.deltaTime;
		
        transform.position = Vector3.MoveTowards(transform.position, target.position, step); //Moves the object on the Z axis i.e down the screen
    }

}
