﻿using UnityEngine;
using System.Collections;

public class CollectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider2D) {
		switch (collider2D.gameObject.name) {
		case "P1Point":
			GameManager.p1Points += 100;
			Destroy(collider2D.gameObject);
			break;
		case "P2Point":
			GameManager.p2Points += 100;
			Destroy(collider2D.gameObject);
			break;
		case "Fuel":
			GameManager.currentFuel += 50;
			Destroy(collider2D.gameObject);
			break;
		case "Astroid":
			GameManager.ExplodeMothership();
			break;
		default:
			break;
		}
	}
}