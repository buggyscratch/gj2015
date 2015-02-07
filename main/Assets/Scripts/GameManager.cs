using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int startingFuel;
	private int currentFuel, p1Points, p2Points;
	private Text fuelLabel, p1PointsLabel, p2PointsLabel;

	// Use this for initialization
	void Start () {
		ResourceSetup ();
		UISetup ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateResources ();
		UIUpdate ();
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
	}

	void UIUpdate(){
		fuelLabel.text = string.Format("{0} {1}", Constants.UIElements.FuelLabelText, currentFuel.ToString());
		p1PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p1Points.ToString());
		p2PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p2Points.ToString());
	}
}
