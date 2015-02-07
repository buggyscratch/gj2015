using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	float speed;
	public Rigidbody2D motherShipRigidBody2D;
	public Transform motherShipTransform;
	public float targetSpeed = 10;
	// Use this for initialization
	void Start () {
		motherShipRigidBody2D = GameObject.Find ("MotherShip").GetComponent<Rigidbody2D>();
		motherShipTransform = GameObject.Find ("MotherShip").GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update() {
		speed += Input.GetAxis ("Vertical");
		transform.rotation = Quaternion.Euler(new Vector3(0,0,speed*targetSpeed));
		/*if(Input.GetKeyDown(KeyCode.Space)){
			Vector2 dir = motherShipTransform.position - transform.position;
				motherShipRigidBody2D.AddForce(Vector2.up);
		}*/

	}
}
