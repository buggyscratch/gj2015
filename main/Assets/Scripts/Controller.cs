using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public Transform motherShip_t, sprite;
	public Rigidbody2D motherShip_r2d;
	public float targetSpeed, shotForce;
	public string axis, fire;

	private float speed;

	// Use this for initialization
	void Start () {
		if (axis.Equals("Vertical")){
			speed = 180;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition ();
		UpdateInteraction ();
		//FollowMothership ();
	}

	//Updates rotation speed based on player input and decelaration
	void UpdatePosition()
	{	
		speed += Input.GetAxis (axis) * targetSpeed;
		transform.rotation = Quaternion.Euler(new Vector3 (0f,0f,speed));
	}

	void UpdateInteraction(){
		if (Input.GetButtonDown (fire)) {
			Vector2 temp = new Vector2(motherShip_t.position.x-sprite.position.x,motherShip_t.position.y-sprite.position.y).normalized;
			motherShip_r2d.AddForce(temp * shotForce);
		}
	}

	//Not usable
	void FollowMothership()	{
		Vector2 toMothership = new Vector2 (motherShip_t.position.x - transform.position.x, motherShip_t.position.y - transform.position.y);
		Debug.Log (toMothership);
		transform.position = motherShip_t.position;
		//transform.Translate (toMothership*0.001f);
	}
}