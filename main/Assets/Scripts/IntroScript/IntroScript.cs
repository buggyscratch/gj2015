using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public string startLevel = "level1";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel(1);
		}
	}
}
