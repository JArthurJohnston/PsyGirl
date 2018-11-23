using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildupPowerController : MonoBehaviour {
	public int maxEnergy;
	public float forceBuildupPerSecond;
	public AbstractPower power;
	float forceEnergy;
	public string InputName {get; set;}

	void Start(){
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, maxEnergy);
	}

	void Update () {
		//fires on the R Trigger on a 360 controller
		if(Input.GetAxis(InputName) > 0){ 
			forceEnergy += forceBuildupPerSecond * (Time.deltaTime / 1);
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
