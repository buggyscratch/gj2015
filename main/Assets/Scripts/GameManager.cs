using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	public int startingFuel, secondsToHyperjump;
	public int currentFuel, p1Points, p2Points;
	public CanvasGroup winCanvas, pausedCanvas, uiCanvas, gameoverCanvas, introCanvas;
	private Text fuelLabel, p1PointsLabel, p2PointsLabel;
	public static GameState state;
	public DateTime startTime;
	public Mothership mothership;
	public int thisLevel, nextLevel;

	// Use this for initialization
	void Start () {
		ResourceSetup ();
		UISetup ();
		state = GameState.Title;
		startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		if (state == GameState.Title) {
			if(Input.anyKeyDown)
			{
				state = GameState.Running;
			}
		}

		if (state == GameState.GameOver) {
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(thisLevel);
			}
		}

		if (state == GameState.Win) {
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(nextLevel);
			}
		}

		if (state == GameState.Running) {
			UpdateResources ();
			UIUpdate ();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (state == GameState.Running)	{
				PauseGame(true);
				
			}
			else if (state == GameState.Paused){
				PauseGame(false);
			}
		}
	}

	public void PauseGame(bool shouldPause)
	{
		if (shouldPause) {
			state = GameState.Paused;
			uiCanvas.alpha = 0f;
			winCanvas.alpha = 0f;
			gameoverCanvas.alpha = 0f;
			pausedCanvas.alpha = 1f;
			introCanvas.alpha = 0f;
		} else {
			state = GameState.Running;
			uiCanvas.alpha = 1f;
			winCanvas.alpha = 0f;
			gameoverCanvas.alpha = 0f;
			pausedCanvas.alpha = 0f;
			introCanvas.alpha = 0f;
		}
	}

	public void ExplodeMothership(){
		GameOver ();
	}

	public void WinLevel(){
		state = GameState.Win;
		uiCanvas.alpha = 0f;
		winCanvas.alpha = 1f;
		gameoverCanvas.alpha = 0f;
		pausedCanvas.alpha = 0f;
		introCanvas.alpha = 0f;
	}

	void UISetup(){
		fuelLabel = GameObject.Find(Constants.UIElements.FuelLabel).GetComponent<Text>();
		p1PointsLabel = GameObject.Find (Constants.UIElements.P1PointsLabel).GetComponent<Text> ();
		p2PointsLabel = GameObject.Find (Constants.UIElements.P2PointsLabel).GetComponent<Text> ();
		uiCanvas.alpha = 0f;
		winCanvas.alpha = 0f;
		gameoverCanvas.alpha = 0f;
		pausedCanvas.alpha = 0f;
		introCanvas.alpha = 1f;
	}

	public void GameOver()
	{		
		state = GameState.GameOver;
		uiCanvas.alpha = 0f;
		winCanvas.alpha = 0f;
		gameoverCanvas.alpha = 1f;
		pausedCanvas.alpha = 0f;
		introCanvas.alpha = 0f;
	}

	void ResourceSetup(){
		currentFuel = startingFuel;
	}

	void UpdateResources(){
		currentFuel--;
		if (currentFuel <= 0) {
			GameOver();
		}
		if (startTime.AddSeconds (secondsToHyperjump) > DateTime.Now) {
			WinLevel();
		}
	}

	void UIUpdate(){
		uiCanvas.alpha = 1f;
		winCanvas.alpha = 0f;
		gameoverCanvas.alpha = 0f;
		pausedCanvas.alpha = 0f;
		introCanvas.alpha = 0f;
		fuelLabel.text = string.Format("{0} {1}", Constants.UIElements.FuelLabelText, currentFuel.ToString());
		p1PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p1Points.ToString());
		p2PointsLabel.text = string.Format("{0} {1}",Constants.UIElements.PlayerPointsText, p2Points.ToString());
	}
}
