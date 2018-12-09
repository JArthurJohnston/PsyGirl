using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessDetector : MonoBehaviour {

	private GameObject[] lights;

	public float distanceThreashold;

	// Use this for initialization
	void Start () {
		lights = GameObject.FindGameObjectsWithTag("Light Source");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var totalLuminescence = 0f;
		foreach (var eachLight in lights)
		{
			Light light = eachLight.GetComponent<Light>();
			var distanceToPlayer = Vector3.Distance(eachLight.transform.position, Player.Main.transform.position);
			if(distanceToPlayer <= distanceThreashold){
				totalLuminescence += light.intensity/distanceToPlayer;
			}
		}
		Player.Main.LightLevel = totalLuminescence;
	}
}
