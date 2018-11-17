using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingAround : EnemyState {
    static Quaternion ninetyDegrees = Quaternion.Euler(0, 90, 0);

    public float turningSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        controller.StartCoroutine(lookAround(animator));
    }

    IEnumerator lookAround(Animator animator){
        agent.enabled = false;
        yield return new WaitForSeconds(1f);
        rotate(animator, ninetyDegrees);
        yield return new WaitForSeconds(1f);
        rotate(animator, ninetyDegrees);
        yield return new WaitForSeconds(1f);
        rotate(animator, ninetyDegrees);
        agent.enabled = true;
        animator.SetBool(ARRIVED_AT_WAYPOINT, false);
    }

    void rotate(Animator animator, Quaternion degrees){
        Debug.Log("rotating");
        var rotation  = animator.gameObject.transform.rotation * degrees; // this adds a 90 degrees Y rotation
        animator.gameObject.transform.rotation = 
            Quaternion.Slerp(animator.gameObject.transform.rotation, rotation, turningSpeed);
	}
}