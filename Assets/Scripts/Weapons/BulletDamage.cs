using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletDamage : MonoBehaviour {
	public float blastRadius;
	public float force;
	public float Damage {get; set;}

	void OnTriggerEnter(Collider collider){
		Destroy(gameObject);
		AddForceToTarget(collider);
		if(collider.gameObject.tag == "Player"){
			DamagePlayer(collider);
		} else {
			checkForAndDisableNavAgentOn(collider);
		}
	}

	void AddForceToTarget(Collider collider){
		var rigidBody = collider.gameObject.GetComponent<Rigidbody>();
		if(rigidBody)
			rigidBody.AddExplosionForce(force, transform.position, blastRadius, 0.0f, ForceMode.Impulse);
	}

	void DamagePlayer(Collider collider){
		if(collider.gameObject.tag == "Player")
			Player.Resources.Health -= Damage;
	}

	void checkForAndDisableNavAgentOn(Collider collider){
		var navAgent = collider.gameObject.GetComponent<NavMeshAgent>();
		if(navAgent){
			navAgent.enabled = false;
		}
	}
}
