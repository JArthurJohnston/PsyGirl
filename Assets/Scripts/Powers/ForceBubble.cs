using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceBubble : MonoBehaviour {

	public float lifespan;
	public float speed;

	public float blastRadius;

	public float force;

	void Start() {
		Destroy(gameObject, lifespan);
	}
	
	void Update () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider collider){
		checkForAndDisableNavAgentOn(collider);
		collider.gameObject.GetComponent<Rigidbody>()
			.AddExplosionForce(force, transform.position, blastRadius, 0.0f, ForceMode.Impulse);
	}

	void checkForAndDisableNavAgentOn(Collider collider){
		var navAgent = collider.gameObject.GetComponent<NavMeshAgent>();
		if(navAgent){
			navAgent.enabled = false;
		}
	}
}
