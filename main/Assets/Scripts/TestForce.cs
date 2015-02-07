using UnityEngine;
using System.Collections;

public class TestForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody2D.AddForce(new Vector2(0,5));
		}
	}
}
