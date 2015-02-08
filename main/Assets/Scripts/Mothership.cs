using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {

	public float anchorX, anchorY, returnSpeed;
	public MothershipState state;
	public GameManager manager;

	// Use this for initialization
	void Start () {
		state = MothershipState.Normal;
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameState.Running) {
			CheckWin();
			MoveMothership ();
		}
	}

	void CheckWin(){
		if (anchorY - transform.position.y < 1) {
			manager.WinLevel();
		}
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

		if (shouldMove) {
			Vector3 movement = new Vector3(anchorX-transform.position.x,anchorY-transform.position.y,0f);
			if (movement.magnitude > returnSpeed){
				movement.Normalize();
				movement *= returnSpeed;
			}
			transform.Translate(movement);
		}
	}
}