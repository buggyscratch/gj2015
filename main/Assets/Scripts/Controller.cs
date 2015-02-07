using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float targetSpeed, speed;
	public string axis;

	// Use this for initialization
	void Start () {
		if (axis.Equals("Vertical")){
			speed = 180;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition ();
	}

	//Updates rotation speed based on player input and decelaration
	void UpdatePosition()
	{	
		speed += Input.GetAxis (axis) * targetSpeed;
		transform.rotation = Quaternion.Euler(new Vector3 (0f,0f,speed));
	}
}