using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : StateMachineBehaviour {
	protected NavMeshAgent agent;
    protected EnemyController controller;
	public const string ARRIVED_AT_WAYPOINT = "arrivedAtWaypoint";
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		agent = animator.gameObject.GetComponent<NavMeshAgent>();
        controller = animator.gameObject.GetComponent<EnemyController>();
    }

}