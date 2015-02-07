using UnityEngine;
using System.Collections;

public class Constants {
	public const string Title = "Defenders of the Obvious";
	public const string Pause = "Paused";
	public const string Placeholder = "PLACEHOLDER";

	public const double ShotDelay = 3;

	public class UIElements {
		public const string FuelLabel = "UIFuel";
		public const string P1PointsLabel = "P1UIPoints";
		public const string P2PointsLabel = "P2UIPoints";
		public const string PlayerPointsText = "POINTS";
		public const string FuelLabelText = "Remaining Fuel";
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
	Menu,
	GameOver
}