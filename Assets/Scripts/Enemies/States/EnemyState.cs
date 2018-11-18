using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : StateMachineBehaviour {
	protected NavMeshAgent agent;
    protected EnemyController controller;
	public const string ARRIVED_AT_WAYPOINT = "arrivedAtWaypoint";
    public const string CAN_SEE_PLAYER = "canSeeThePlayer";
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		agent = animator.gameObject.GetComponent<NavMeshAgent>();
        controller = animator.gameObject.GetComponent<EnemyController>();
    }

    /*
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
     */

}