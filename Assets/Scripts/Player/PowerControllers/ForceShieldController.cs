using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShieldController : AbstractPowerController {

	ForceShield effect;

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
			DropShields();
		}
	}

	void RaiseShields(){
		ShieldsRaised = true;
		effect.PowerUp();
	}

	void DropShields(){
		ShieldsRaised = false;
		effect.PowerDown();
	}
}
