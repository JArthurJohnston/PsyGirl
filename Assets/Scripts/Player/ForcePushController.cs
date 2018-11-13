using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushController : MonoBehaviour {
	public int cost;
	public Resources playerResources;
	public float attackRadius;
	public float attackPower;
	public GameObject playerBody;
	public TargetCircle targetCircle;
	public float range;

	float forceEnergy;
	public float forceBuildupPerSecond;

	public ForceBubble forceSphereTemplate;

	void Start(){
		forceEnergy = 0;
	}

	float builtUpForceEnergy(){
		return Mathf.Min(forceEnergy, cost);
	}

	void Update () {
		// raycastExplosion();
		//fires on the A button on a 360 controller
		if(Input.GetAxis("Fire1") > 0){ 
			forceEnergy += forceBuildupPerSecond;
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
		}
	}

	void raycastExplosion(){
		RaycastHit hit;
		var startingPosition = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.25f, playerBody.transform.position.z);
		var ray = new Ray(startingPosition, playerBody.transform.forward);
		Debug.DrawRay(startingPosition, playerBody.transform.forward, Color.red);
		if(Physics.Raycast(ray, out hit, range) && hit.collider.gameObject.tag == "Moveable"){
			showTarget(hit.transform.position);
			if(Input.GetAxis("Fire1") > 0){ //fires on the A button on a 360 controller
				attackAllEnemiesAroundPoint(hit.transform.position);
			}
		} else {
			targetCircle.hide();
		}
	}

	void showTarget(Vector3 hitPosition){
		targetCircle.DrawAt(hitPosition, attackRadius);
	}

	void attackAllEnemiesAroundPoint(Vector3 position){
		if(playerResources.PsyEnergy >= cost){
			playerResources.PsyEnergy -= cost;
			var colliders = Physics.OverlapSphere (position, attackRadius);
			foreach (Collider enemy in colliders){
				if(enemy && enemy.GetComponent<Rigidbody>()){
					enemy.GetComponent<Rigidbody>().AddExplosionForce(attackPower, position, attackRadius, 0.0f, ForceMode.Impulse);
				}
			}
		}
	}
}
