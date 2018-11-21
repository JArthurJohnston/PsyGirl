using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShieldController : MonoBehaviour {

	public ForceShield ForceShieldTemplate;

	bool ShieldsRaised;

	void Start(){
		ShieldsRaised = false;
	}

	void Update () {
		if(Input.GetAxis("Pause") > 0){
			if(!ShieldsRaised)
				RaiseShields();
		} else {
			DropShields();
		}
	}

	void RaiseShields(){
		ShieldsRaised = true;
	}

	void DropShields(){
		ShieldsRaised = false;
	}
}
