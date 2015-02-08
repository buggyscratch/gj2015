using UnityEngine;
using System.Collections;

public class CollectScript : MonoBehaviour {
	public AudioClip collectSound;
	public GameManager manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider2D) {
		switch (collider2D.gameObject.name) {
		case "P1Point":
			manager.p1Points += 100;
			audio.PlayOneShot(collectSound);
			Destroy(collider2D.gameObject);
			break;
		case "P2Point":
			manager.p2Points += 100;
			audio.PlayOneShot(collectSound);
			Destroy(collider2D.gameObject);
			break;
		case "Fuel":
			manager.currentFuel += 500;
			audio.PlayOneShot(collectSound);
			Destroy(collider2D.gameObject);
			break;
		case "Astroid":
			manager.ExplodeMothership();
			break;
		case "LevelComplete":
			manager.WinLevel();
			break;
		default:
			break;
		}
	}
}