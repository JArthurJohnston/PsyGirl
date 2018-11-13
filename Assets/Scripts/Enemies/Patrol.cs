using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {
	NavMeshAgent agent;

	NavPoint destination;

	private bool movingToDestination;
	public float arrivedBuffer;

	void Start(){
		movingToDestination = true;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		if(agent.enabled && (destination == null || arrivedAtDestination())){
			goToNewDestination();
		}
	}

	bool arrivedAtDestination(){
		return agent.remainingDistance < arrivedBuffer;
	}

	void goToNewDestination(){
		destination = Navigator.getNewNavPoint();
		agent.SetDestination(destination.transform.position);
	}
}
