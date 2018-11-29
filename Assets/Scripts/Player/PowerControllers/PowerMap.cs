using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMap : MonoBehaviour {
	public AbstractPowerController[] powers;

	public int primaryPowerIndex;
	public int secondaryPowerIndex;

	void Start(){
		foreach (var power in powers)
		{
			power.Initialize();
		}
	}

	private AbstractPowerController PowerAt(int index){
		if(powers[index] == null){
			return AbstractPowerController.NO_POWER;
		}
		return powers[index];
	}

	private AbstractPowerController PrimaryPower(){
		return PowerAt(primaryPowerIndex);
	}
	
	private AbstractPowerController SecondaryPower(){
		return PowerAt(secondaryPowerIndex);
	}

	void Update () {
		if(Time.timeScale != 0){
			PrimaryPower().Handle(Input.GetAxis("Attack2"));
			SecondaryPower().Handle(Input.GetAxis("Attack1"));
		}
	}
}
