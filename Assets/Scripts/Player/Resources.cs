using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {

	float timeSinceLastUpdate = 0;
	public float healthRegenValue;
	public float psyRegenValue;
	public float Health;
	public float PsyEnergy;
	public int MaxHealth;
	public int MaxPsyEnergy;

	void Update(){
		timeSinceLastUpdate += Time.deltaTime;
		if(timeSinceLastUpdate > 2) {
			Health = Math.Min(Health + healthRegenValue, MaxHealth);
			PsyEnergy = Math.Min(PsyEnergy + psyRegenValue, MaxPsyEnergy);
			timeSinceLastUpdate = 0;
		}
	}
}
