using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
	public GameObject target;

	public bool followX;
	public bool followY;
	[Range(0F, 1F)]
	public float slur = 0.5F;
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		x = transform.position.x;

		y = transform.position.y;

		
		target.transform.position = new Vector3(x*slur,y*slur);
	}
}