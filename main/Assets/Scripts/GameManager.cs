using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int startingFuel;
	private int currentFuel;
	private Text fuelLabel;

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
	}

	void ResourceSetup(){
		currentFuel = startingFuel;
	}

	void UpdateResources(){
		currentFuel--;
	}

	void UIUpdate(){
		fuelLabel.text = Constants.UIElements.FuelLabelText.Replace(Constants.Placeholder,currentFuel.ToString());
	}
}
