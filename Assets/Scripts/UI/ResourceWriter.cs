using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceWriter : MonoBehaviour {

	public Text healthLabel;
	public Text psyLabel;
	
	void Update () {
		healthLabel.text = "Health: " + Player.Resources.Health;
		psyLabel.text = "Psy: " + Player.Resources.PsyEnergy;
	}
}
