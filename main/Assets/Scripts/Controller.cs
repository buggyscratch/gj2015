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
	public AudioClip repulsorSound;

	PerlinNoise perlin1;
	PerlinNoise perlin2;
	float time;

	private float speed;
	private DateTime shotTime;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		if (axis.Equals("Vertical")){
			speed = 180;
		}
		perlin1 = new PerlinNoise(UnityEngine.Random.Range(0,16));
		perlin2 = new PerlinNoise(UnityEngine.Random.Range(0,16));
		shotTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {


		time += Time.deltaTime;
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
		FollowMothership ();
	}

	void ShootRepulsor(){
		Vector2 temp = new Vector2(motherShip_t.position.x-sprite.position.x,motherShip_t.position.y-sprite.position.y);
		motherShip_r2d.AddForce(temp.normalized * shotForce);
		audio.pitch = UnityEngine.Random.Range (0.9f, 1.1f);
		audio.PlayOneShot (repulsorSound);
		shotTime = DateTime.Now;
	}

	//Not usable
	void FollowMothership()	{
		Vector2 toMothership = new Vector2 (motherShip_t.position.x - transform.position.x, motherShip_t.position.y - transform.position.y);
		Debug.Log (toMothership);
		transform.position = new Vector2 (motherShip_t.position.x + perlin1.FractalNoise2D(new Vector2(sprite.position.x + time ,sprite.position.y + time),8,0.03f,2f,0.5f,1f), motherShip_t.position.y + perlin2.FractalNoise2D(new Vector2(sprite.position.x + time,sprite.position.y + time),8,0.03f,1f,0.5f,1f));
		//transform.Translate (toMothership*0.001f);
	}
}