using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Controller : MonoBehaviour {
	public Transform motherShip_t, sprite;
	public Rigidbody2D motherShip_r2d;
	public RawImage shotDot;
	public float targetSpeed, shotForce;
	public string axis, fire;

	private float speed;
	private DateTime shotTime;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		if (axis.Equals("Vertical")){
			speed = 180;
		}
		shotTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		canShoot = DateTime.Now > shotTime.AddSeconds (Constants.ShotDelay);

		shotDot.CrossFadeAlpha (canShoot ? 1 : 0, 0.2f, false);

		UpdatePosition ();

		if (Input.GetButtonDown (fire) && canShoot) {
			ShootRepulsor ();
		}
	}

	//Updates rotation speed based on player input and decelaration
	void UpdatePosition()
	{	
		speed += Input.GetAxis (axis) * targetSpeed;
		transform.rotation = Quaternion.Euler(new Vector3 (0f,0f,speed));
	}

	void ShootRepulsor(){
		Vector2 temp = new Vector2(motherShip_t.position.x-sprite.position.x,motherShip_t.position.y-sprite.position.y);
		motherShip_r2d.AddForce(temp.normalized * shotForce);
		shotTime = DateTime.Now;
	}

	//Not usable
	void FollowMothership()	{
		Vector2 toMothership = new Vector2 (motherShip_t.position.x - transform.position.x, motherShip_t.position.y - transform.position.y);
		Debug.Log (toMothership);
		transform.position = motherShip_t.position;
		//transform.Translate (toMothership*0.001f);
	}
}