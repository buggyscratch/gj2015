using UnityEngine;
using System.Collections;

public class Constants {
	public const string Title = "Defenders of the Obvious";
	public const string Pause = "Paused";
	public const string Placeholder = "PLACEHOLDER";

	public const double ShotDelay = 1;
	public const int MaxShots = 2;

	public class UIElements {
		public const string FuelLabel = "UIFuel";
		public const string P1PointsLabel = "P1UIPoints";
		public const string P2PointsLabel = "P2UIPoints";
		public const string PlayerPointsText = "POINTS";
		public const string FuelLabelText = "Remaining Fuel";
		public const string PausedCanvas = "PausedCanvas";
		public const string UICanvas = "UICanvas";
		public const string IntroCanvas = "IntroCanvas";
		public const string WinCanvas = "WinCanvas";
		public const string GameOverCanvas = "GameOverCanvas";
	}
}

public enum MothershipState{
	Normal,
	Returning,
	Pushed,
	Destroyed
}

public enum GameState{
	Running,
	Paused,
	Title,
	GameOver,
	Win
}