using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushController : MonoBehaviour {
	public int maxEnergy;
	public Resources playerResources;
	public GameObject playerBody;
	float forceEnergy;
	public float forceBuildupPerSecond;
	public ForceBubble forceSphereTemplate;

	void Start(){
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, maxEnergy);
	}

	void Update () {
		//fires on the A button on a 360 controller
		if(Input.GetAxis("Fire1") > 0){ 
			forceEnergy += forceBuildupPerSecond * (Time.deltaTime / 1);
		} else if(forceEnergy > 0){
			releaseForceEnergy();
			forceEnergy = 0;
		}
	}

	void releaseForceEnergy(){
		var energy = builtUpForceEnergy();
		if(playerResources.PsyEnergy >= energy){
			playerResources.PsyEnergy -= energy;
			var position = playerBody.transform.position + playerBody.transform.forward;
			ForceBubble forceSphere = Instantiate(forceSphereTemplate, position, playerBody.transform.rotation);
			forceSphere.force = energy;
		}
	}
}
