using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public Transform motherShip_t;
	public Rigidbody2D motherShip_r2d;
	public float targetSpeed;
	private float speed;
	public string axis;
	public string fire;

	// Use this for initialization
	void Start () {
		if (axis.Equals("Vertical")){
			speed = 180;
		}

		motherShip_t = GameObject.Find ("Mothership").GetComponent<Transform> ();
		motherShip_r2d = GameObject.Find ("Mothership").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition ();
		UpdateInteraction ();
	}

	//Updates rotation speed based on player input and decelaration
	void UpdatePosition()
	{	
		speed += Input.GetAxis (axis) * targetSpeed;
		transform.rotation = Quaternion.Euler(new Vector3 (0f,0f,speed));
	}

	void UpdateInteraction(){
		if (Input.GetButtonDown (fire)) {
			Debug.Log ("fired");
			Vector2 temp = new Vector2(0,0);	// HVAD SKAL TEMP VÆRE !!!
			motherShip_r2d.AddForce(temp);
		}
	}
}