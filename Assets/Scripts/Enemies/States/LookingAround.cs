using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingAround : EnemyState {
    static Quaternion ninetyDegrees = Quaternion.Euler(0, 90, 0);

    float turningSpeed = 0.15f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        controller.StartCoroutine(lookAround(animator));
    }

    IEnumerator lookAround(Animator animator){
        yield return new WaitForSeconds(1f);
        // rotate(animator, ninetyDegrees);
        // yield return new WaitForSeconds(1f);
        // rotate(animator, ninetyDegrees);
        // yield return new WaitForSeconds(1f);
        rotate(animator, ninetyDegrees);
        animator.SetBool(ARRIVED_AT_WAYPOINT, false);
    }

    void rotate(Animator animator, Quaternion degrees){
            var rotation  = animator.gameObject.transform.rotation * degrees; // this adds a 90 degrees Y rotation
            animator.gameObject.transform.rotation = 
                Quaternion.Slerp(animator.gameObject.transform.rotation, rotation, Time.deltaTime * turningSpeed);
	}
}