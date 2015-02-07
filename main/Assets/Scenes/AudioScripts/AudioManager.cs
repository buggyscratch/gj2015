using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioClip repulsiveSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void PlayRepulsiveSound(){
		if (Input.GetButtonDown ("Fire1") && Input.GetButtonDown ("Fire2")) {
			audio.PlayOneShot(repulsiveSound);
		}
	}
}
