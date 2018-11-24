using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMap : MonoBehaviour {
	public AbstractPowerController[] powers;

	int primaryPowerIndex;
	int secondaryPowerIndex;

	void Start(){
		InitializeEmptyPowers();
	}

	void InitializeEmptyPowers(){
		for (int i = powers.Length - 1; i >= 0 ; i--)
		{
			if(powers[i] == null){
				powers[i] = AbstractPowerController.NO_POWER;
			} else {
				powers[i].Initialize();
			}
		}
	}

	private AbstractPowerController PrimaryPower(){
		if(powers[primaryPowerIndex] == null){
			return AbstractPowerController.NO_POWER;
		}
		return powers[primaryPowerIndex];
	}
		
	private AbstractPowerController SecondaryPower(){
		if(powers[secondaryPowerIndex] == null){
			return AbstractPowerController.NO_POWER;
		}
		return powers[secondaryPowerIndex];
	}

	// Update is called once per frame
	void Update () {
		powers[primaryPowerIndex].Handle(Input.GetAxis("Attack2"));
		// powers[secondaryPowerIndex].Handle(Input.GetAxis("Attack2"));
	}
}
