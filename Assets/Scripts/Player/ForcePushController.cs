using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushController : MonoBehaviour {
	public int maxEnergy;
	public float forceBuildupPerSecond;
	public ForceBubble forceSphereTemplate;
	float forceEnergy;

	void Start(){
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, maxEnergy);
	}

	void Update () {
		//fires on the R Trigger on a 360 controller
		if(Input.GetAxis("Attack2") > 0){ 
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
			ForceBubble forceSphere = Instantiate(forceSphereTemplate, position, transform.rotation);
			forceSphere.force = energy;
		}
	}
}
