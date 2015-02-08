using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Controller : MonoBehaviour {
	public Transform motherShip_t, sprite;
	public Rigidbody2D motherShip_r2d;
	public RawImage shotDot1, shotDot2;
	public Animator shot;
	public float targetSpeed, shotForce;
	public string axis, fire;
	public AudioClip repulsorSound;

	PerlinNoise perlin1;
	PerlinNoise perlin2;
	float time;

	private float speed;
	private DateTime rechargeTime;
	private int shots;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		shots = 0;
		shotDot1.CrossFadeAlpha (0, 0.2f, false);
		shotDot2.CrossFadeAlpha (0, 0.2f, false);
		if (axis.Equals("Vertical")){
			speed = 180;
		}
		perlin1 = new PerlinNoise(UnityEngine.Random.Range(0,16));
		perlin2 = new PerlinNoise(UnityEngine.Random.Range(0,16));
		rechargeTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameState.Running) {
			time += Time.deltaTime;
			canShoot = DateTime.Now > rechargeTime.AddSeconds (Constants.ShotDelay);
			if (canShoot && shots < Constants.MaxShots){
				shots++;
				if (shots==1){
					shotDot1.CrossFadeAlpha (1, 0.2f, true);
				}
				if (shots==2){
					shotDot2.CrossFadeAlpha (1, 0.2f, true);
				}
				rechargeTime = DateTime.Now;
			}

			UpdatePosition ();

			if (Input.GetButtonDown (fire) && shots > 0) {
				ShootRepulsor ();
				shots--;
				if (shots==0){
					shotDot1.CrossFadeAlpha (0, 0.2f, true);
				}
				if (shots==1){
					shotDot2.CrossFadeAlpha (0, 0.2f, true);
				}
			}
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
		shot.Play (0);
		Vector2 temp = new Vector2(motherShip_t.position.x-sprite.position.x,motherShip_t.position.y-sprite.position.y);
		motherShip_r2d.AddForce(temp.normalized * shotForce);
		audio.pitch = UnityEngine.Random.Range (0.9f, 1.1f);
		audio.PlayOneShot (repulsorSound);
	}

	//Not usable
	void FollowMothership()	{
		transform.position = new Vector2 (motherShip_t.position.x + perlin1.FractalNoise2D(new Vector2(sprite.position.x + time ,sprite.position.y + time),8,0.03f,2f,0.5f,1f), motherShip_t.position.y + perlin2.FractalNoise2D(new Vector2(sprite.position.x + time,sprite.position.y + time),8,0.03f,1f,0.5f,1f));
		shot.transform.position = transform.position;
	}
}