using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

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
			
			if(followX){
				x = transform.position.x;
			}
			if(followY){
				y = transform.position.y;
			}
			
			Camera.main.transform.position = new Vector3(x*slur,y,-10);
		}
	}


