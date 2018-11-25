using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShieldController : AbstractPowerController {

	ForceShield effect;

	GameObject shield;

	bool ShieldsRaised;

	public override void Initialize(){
		effect = GetComponent<ForceShield>();
		ShieldsRaised = false;
	}

	public override void Handle (float input) {
		if(input > 0){
			if(!ShieldsRaised)
				RaiseShields();
		} else {
			if(ShieldsRaised)
				DropShields();
		}
	}

	void RaiseShields(){
		ShieldsRaised = true;
		shield = effect.RaiseNewShields();
	}

	void DropShields(){
		ShieldsRaised = false;
		Destroy(shield);
	}
}
