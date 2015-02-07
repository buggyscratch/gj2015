using UnityEngine;
using System.Collections;

public class Woople : MonoBehaviour {
	Vector2 thisPosition;
	public float amount = 4;
	PerlinNoise perlin;
	float time;
	// Use this for initialization
	void Start () {
		perlin = new PerlinNoise(1);
		thisPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameState.Running) {
			time += Time.deltaTime;
			transform.position = new Vector2 (thisPosition.x + perlin.FractalNoise2D (new Vector2 (thisPosition.x + time, thisPosition.y + time), 8, 0.03f, 2f, 0.5f, amount), thisPosition.y + perlin.FractalNoise2D (new Vector2 (thisPosition.y + time, thisPosition.y + time), 8, 0.03f, 2f, 0.5f, amount));
		}
	}
}
