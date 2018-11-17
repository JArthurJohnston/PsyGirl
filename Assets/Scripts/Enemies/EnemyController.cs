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

    IEnumerator lookAround(){
        yield return new WaitForSeconds(1f);
        rotate(Quaternion.Euler(0, 90, 0));
        yield return new WaitForSeconds(1f);
        rotate(Quaternion.Euler(0, 90, 0));
        yield return new WaitForSeconds(1f);
        rotate(Quaternion.Euler(0, 90, 0));
        animator.SetBool(EnemyState.ARRIVED_AT_WAYPOINT, false);
    }

    void rotate(Quaternion degrees){
            var rotation  = gameObject.transform.rotation * degrees; // this adds a 90 degrees Y rotation
            gameObject.transform.rotation = 
                Quaternion.Slerp(gameObject.transform.rotation, rotation, Time.deltaTime * 0.15f);
	}

	public void StartLooking() {
		StartCoroutine(lookAround());
	}

	void goToNewDestination(){
		if(agent.enabled){
			destination = Navigator.getNewNavPoint();
			agent.SetDestination(destination.transform.position);
			animator.SetBool(EnemyState.ARRIVED_AT_WAYPOINT, false);
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
