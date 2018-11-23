using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceBlast : AbstractPower {

	public float ExpansionSpeed;
	public float TimeToLive;
	public float blastRadius;

	void Start () {
		Destroy(gameObject, TimeToLive);
	}
	
	void Update () {
		var expanded = Time.deltaTime * ExpansionSpeed;
		transform.localScale += new Vector3(expanded, expanded, expanded);
	}

	void OnTriggerEnter(Collider collider){
		checkForAndDisableNavAgentOn(collider);
		Debug.Log("Collided With: " + collider.gameObject.name);
		collider.gameObject.GetComponent<Rigidbody>()
			.AddExplosionForce(Force, transform.position, transform.localScale.x, 0.0f, ForceMode.Impulse);
		/*
		I can think of three ways to do this
			1) expand the bubble and add explosion force/velocity at each collision point
			2) add explosion force at the center with a blast radius == the size of the bubble
			3) git rid of the collider alltogether and use a constant explosion force radiating from the player
				-	Id still have to find all the game objects/rigidbodies around the player
				-	use the bubble just for visuals
		 */
	}

	void checkForAndDisableNavAgentOn(Collider collider){
		var navAgent = collider.gameObject.GetComponent<NavMeshAgent>();
		if(navAgent){
			navAgent.enabled = false;
		}
	}
}
