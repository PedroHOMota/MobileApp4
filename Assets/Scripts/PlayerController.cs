using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public int speed = 5;
	public Boundary bnd = new Boundary();
	public int tilt = 4;
    public GameObject shot;
    public Transform shotSpawn;
    public int amountOfShots = 1; //Upgrades will alow the player to shoot more than one bean at a time
    private float nextFire = 0.0F;
    public float fireRate;
    void Start () {
		rb=GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        
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
