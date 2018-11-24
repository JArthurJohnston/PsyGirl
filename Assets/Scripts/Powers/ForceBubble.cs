using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceBubble : MonoBehaviour {

	public float lifespan;
	public float speed;
	public float cost;
	public float chargePerSecond;
	public float blastRadius;

	public float force {get; set;}

	void Start() {
		Destroy(gameObject, lifespan);
	}
	
	void Update () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider collider){
		checkForAndDisableNavAgentOn(collider);
		var colliderRigidBody = collider.gameObject.GetComponent<Rigidbody>();
		Debug.Log("Colliding with: " + force);
		if(colliderRigidBody != null)
			colliderRigidBody.AddExplosionForce(force, transform.position, blastRadius, 0.0f, ForceMode.Impulse);
	}

	void checkForAndDisableNavAgentOn(Collider collider){
		var navAgent = collider.gameObject.GetComponent<NavMeshAgent>();
		if(navAgent){
			navAgent.enabled = false;
		}
	}

	public void Fire(Vector3 position, Quaternion direction, float force){
		var push = Instantiate(this, position, direction);
		push.force = force;
	}
}
