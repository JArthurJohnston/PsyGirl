using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : StateMachineBehaviour {
	NavMeshAgent agent;
	GameObject destination;
	private bool movingToDestination;
	public float arrivedBuffer;

	public const string ARRIVED_AT_WAYPOINT = "arrivedAtWaypoint";

	EnemyController controller;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		movingToDestination = false;
		controller = animator.gameObject.GetComponent<EnemyController>();
		agent = animator.gameObject.GetComponent<NavMeshAgent>();
		// StartCoroutine(lookAround());
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if(ArrivedAtDestination()){
			animator.SetBool(ARRIVED_AT_WAYPOINT, true);
		}
    }
	
	bool ArrivedAtDestination(){
		return agent.enabled ? agent.remainingDistance < arrivedBuffer : false;
	}

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
