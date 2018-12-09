using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceWriter : MonoBehaviour {

	public Text healthLabel;
	public Text psyLabel;
	public Text PrimaryPowerLabel;
	public Text SecondaryPowerLabel;
	public Text StealthLabel;
	
	void Update () {
		healthLabel.text = "Health: " + Player.Resources.Health;
		psyLabel.text = "Psy: " + Player.Resources.PsyEnergy;
		PrimaryPowerLabel.text = "Primary: " + Player.Main.Powers.PrimaryPower().Title;
		SecondaryPowerLabel.text = "Secondary: " + Player.Main.Powers.SecondaryPower().Title;
		StealthLabel.text = "Light: " + Player.Main.LightLevel;
	}
}
