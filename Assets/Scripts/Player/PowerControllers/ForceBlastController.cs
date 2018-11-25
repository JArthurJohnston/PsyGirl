using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlastController : AbstractPowerController {

	ForceBlast effect;
	float forceEnergy;

	public override void Initialize(){
		forceEnergy = 0;
		effect = GetComponent<ForceBlast>();
		if(effect == null){
			Debug.Log("No Effect found for force blast");
		}
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, effect.cost);
	}

    public override void Handle(float input)
    {		
		if(input > 0){ 
			forceEnergy += effect.chargePerSecond * (Time.deltaTime / 1);
		} else if(forceEnergy > 0){
			releaseForceEnergy();
			forceEnergy = 0;
		}
    }

	void releaseForceEnergy(){
		var energy = builtUpForceEnergy();
		if(Player.Resources.PsyEnergy >= energy){
			Player.Resources.PsyEnergy -= energy;
			effect.Fire(energy);
		}
	}
}
