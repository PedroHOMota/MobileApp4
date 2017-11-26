using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int speed = 5;
	public Boundary bnd = new Boundary();
	public int tilt = 4;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement*speed;

		rb.position = new Vector3( //Block the ship from going out of camera's view
			Mathf.Clamp(rb.position.x,bnd.xMin,bnd.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,bnd.zMin,bnd.zMax)
		);

		rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -tilt); //Tilts ships
	}
}
