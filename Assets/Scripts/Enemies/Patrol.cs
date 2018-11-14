using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {
	NavMeshAgent agent;

	GameObject destination;

	private bool movingToDestination;
	public float arrivedBuffer;

	void Start(){
		movingToDestination = false;
		agent = GetComponent<NavMeshAgent>();
		StartCoroutine(lookAround());
	}

	void Update () {
		if(movingToDestination && arrivedAtDestination()){
			movingToDestination = false;
			StartCoroutine(lookAround());
		}
	}

	IEnumerator lookAround() {
		yield return new WaitForSeconds(1f);
		goToNewDestination();
	}

	bool arrivedAtDestination(){
		return agent.remainingDistance < arrivedBuffer;
	}

	void goToNewDestination(){
		destination = Navigator.getNewNavPoint();
		agent.SetDestination(destination.transform.position);
		movingToDestination = true;
	}
}
