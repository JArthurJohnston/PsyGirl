using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanSeePlayer : EnemyState {
    Vision vision;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
		vision = animator.gameObject.transform.GetChild(1).GetComponent<Vision>();
        setDestination(vision.playerPosition);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setDestination(vision.playerPosition);
        if(!vision.canSeePlayer){
            animator.SetBool(EnemyState.CAN_SEE_PLAYER, false);
        }
    }
}
