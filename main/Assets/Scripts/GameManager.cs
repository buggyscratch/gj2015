using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	public int startingFuel, secondsToHyperjump;
	public static int currentFuel, p1Points, p2Points;
	private Text fuelLabel, p1PointsLabel, p2PointsLabel;
	public static GameState state;
	public DateTime startTime;

	// Use this for initialization
	void Start () {
		ResourceSetup ();
		UISetup ();
		state = GameState.Running;
		startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == GameState.Running) {
			UpdateResources ();
			UIUpdate ();
		}
	}

	public static void ExplodeMothership(){
		state = GameState.GameOver;
	}

	void UISetup(){
		fuelLabel = GameObject.Find(Constants.UIElements.FuelLabel).GetComponent<Text>();
		p1PointsLabel = GameObject.Find (Constants.UIElements.P1PointsLabel).GetComponent<Text> ();
		p2PointsLabel = GameObject.Find (Constants.UIElements.P2PointsLabel).GetComponent<Text> ();
	}

	void ResourceSetup(){
		currentFuel = startingFuel;
	}

	void UpdateResources(){
		currentFuel--;
		if (currentFuel <= 0) {
			state = GameState.GameOver;
		}
		if (startTime.AddSeconds (secondsToHyperjump) > DateTime.Now) {
			//Level complete
		}
	}

	void UIUpdate(){
		fuelLabel.text = string.Format("{0} {1}", Constants.UIElements.FuelLabelText, currentFuel.ToString());
		p1PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p1Points.ToString());
		p2PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p2Points.ToString());
	}
}
