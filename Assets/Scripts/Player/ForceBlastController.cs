using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlastController : MonoBehaviour {

	public int maxEnergy;
	public float forceBuildupPerSecond;
	public ForceBlast forceBlastTemplate;
	Resources playerResources;
	float forceEnergy;

	void Start(){
		playerResources = GetComponent<Resources>();
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, maxEnergy);
	}

	void Update () {
		//fires on the A button on a 360 controller
		if(Input.GetAxis("Attack1") > 0){ 
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
			ForceBlast forceSphere = Instantiate(forceBlastTemplate, transform.position, transform.rotation);
			forceSphere.Force = energy;
		}
	}
}
