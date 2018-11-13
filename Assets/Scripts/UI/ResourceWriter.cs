using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceWriter : MonoBehaviour {

	public Resources playerResources;
	public Text healthLabel;
	public Text psyLabel;
	
	void Update () {
		healthLabel.text = "Health: " + (int)playerResources.Health;
		psyLabel.text = "Psy: " + (int)playerResources.PsyEnergy;
	}
}
