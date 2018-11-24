using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushController : AbstractPowerController {
	ForceBubble effect;
	float forceEnergy;

	public override void Initialize(){
		forceEnergy = 0;
		effect = GetComponent<ForceBubble>();
		Debug.Log("CPS: " + effect.chargePerSecond);
		if(effect == null){
			Debug.Log("No Effect found for force push");
		}
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, effect.cost);
	}

	public override void Handle(float input){
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
			var playerTransform = Player.Main.gameObject.transform;
			var inFrontOfPlayer = playerTransform.position + playerTransform.forward;
			effect.Fire(inFrontOfPlayer, playerTransform.rotation, energy);
		}
	}
}
