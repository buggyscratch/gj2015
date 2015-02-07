﻿using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {

	public float anchorX, anchorY, returnSpeed;
	public MothershipState state;


	// Use this for initialization
	void Start () {
		state = MothershipState.Normal;
	}

	// Update is called once per frame
	void Update () {
		MoveMothership ();
	}

	void MoveMothership()
	{
		bool shouldMove = false;
		if (!transform.position.x.Equals (anchorX)) {
			shouldMove = true;
		} else if (!transform.position.y.Equals (anchorY)) {
			shouldMove = true;
		} else {
			state = MothershipState.Normal;
		}

		if (shouldMove && state == MothershipState.Returning) {
			Vector3 movement = new Vector3(anchorX-transform.position.x,anchorY-transform.position.y,0f);
			if (movement.magnitude > returnSpeed){
				movement.Normalize();
				movement *= returnSpeed;
			}
			transform.Translate(movement);
		}
	}
}