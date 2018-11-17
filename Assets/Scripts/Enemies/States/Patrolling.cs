using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : EnemyState {
	public float arrivedBuffer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		base.OnStateEnter(animator, stateInfo, layerIndex);
		goToDestination(animator);
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

	void goToDestination(Animator animator){
		if(agent.enabled){
			agent.SetDestination(Navigator.getNewNavPoint().transform.position);
			animator.SetBool(Patrolling.ARRIVED_AT_WAYPOINT, false);
		}
	}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
