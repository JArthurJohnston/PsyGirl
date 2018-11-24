using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildupPowerController : AbstractPowerController {
	public AbstractPower power;
	float forceEnergy;
	public string InputName {get; set;}

	void Start(){
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, power.MaxCost);
	}

	public override void Handle (float input) {
		if(input > 0){ 
			forceEnergy += power.ChargePerSecond * (Time.deltaTime / 1);
		} else if(forceEnergy > 0){
			releaseForceEnergy();
			forceEnergy = 0;
		}
	}

	void releaseForceEnergy(){
		var energy = builtUpForceEnergy();
		if(Player.Resources.PsyEnergy >= energy){
			Player.Resources.PsyEnergy -= energy;
			var position = transform.position + transform.forward;
			var forceSphere = Instantiate(power, position, transform.rotation);
			forceSphere.Force = energy;
		}
	}
}
