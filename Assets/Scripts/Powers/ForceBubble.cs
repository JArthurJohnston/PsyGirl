using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceBubble : MonoBehaviour {

	public static void Fire(Vector3 position, Quaternion rotation, float force){
		// Instantiate(GameObject)
	}

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
		var colliderRigidBody = collider.gameObject.GetComponent<Rigidbody>();
		if(colliderRigidBody != null)
			colliderRigidBody.AddExplosionForce(force, transform.position, blastRadius, 0.0f, ForceMode.Impulse);
	}

	void checkForAndDisableNavAgentOn(Collider collider){
		var navAgent = collider.gameObject.GetComponent<NavMeshAgent>();
		if(navAgent){
			navAgent.enabled = false;
		}
	}
}
