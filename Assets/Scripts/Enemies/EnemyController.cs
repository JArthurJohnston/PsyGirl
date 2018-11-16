using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	NavMeshAgent agent;
	GameObject destination;
	GameObject player;
	Animator animator;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	IEnumerator lookAround() {
		yield return new WaitForSeconds(1f);
		//add some rotations and pauses
		goToNewDestination();
	}

	public void StartMoving() {
		StartCoroutine(lookAround());
	}

	void goToNewDestination(){
		if(agent.enabled){
			destination = Navigator.getNewNavPoint();
			agent.SetDestination(destination.transform.position);
			animator.SetBool(Patrolling.ARRIVED_AT_WAYPOINT, false);
		}
	}

	public void holdGun(){

	}

	public void dropGun(){
		
	}
	
	public void facePlayer(){
		transform.LookAt(player.transform);
	}
}
