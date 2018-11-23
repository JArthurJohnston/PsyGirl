using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour {
public float lifespan;
	public float speed;
	public float blastRadius;
	public float force;
	public float Damage {get; set;}

	void Start() {
		Destroy(gameObject, lifespan);
	}
	
	void Update () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log("Hit: " + collider.gameObject.name);
		checkForAndDisableNavAgentOn(collider);
		AddForceToTarget(collider);
		DamagePlayer(collider);
		Destroy(gameObject);
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
