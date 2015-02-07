using UnityEngine;
using System.Collections;

public class Constants {
	public const string Title = "Defenders of the Obvious";
	public const string Pause = "Paused";
	public const string Placeholder = "PLACEHOLDER";

	public class UIElements {
		public const string FuelLabel = "UIFuel";
		public const string FuelLabelText = "Remaining Fuel PLACEHOLDER";
	}

}

public enum MothershipState{
	Normal,
	Returning,
	Pushed,
	Destroyed
}