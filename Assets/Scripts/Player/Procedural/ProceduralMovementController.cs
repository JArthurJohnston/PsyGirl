using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMovementController : MonoBehaviour {

    public float turningSpeed;
    public GameObject characterBody;
    public float jumpThreashold = 1f;
    private Rigidbody _rigidbody;
    public float feetAngle = 5f;
    public Transform RightFoot;
    public Transform LeftFoot;

    public float MaxLegLength = 4f;
    private int SkipPlayerMask;


    void Start(){
        // RightFoot = transform.Find("RFoot");
        // LeftFoot = transform.Find("LFoot");
        SkipPlayerMask = RayHelper.allButLayerMask("Player");
        var threshold = FindStandingThreashold();
        if(threshold > 0){
            jumpThreashold = threshold + 0.25f;
        }
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement, float jump){

        var isOnTheGround = IsGrounded();
        RotatePlayer(movement);
        PositionFeet();
        if(jump > 0 && isOnTheGround){
            _rigidbody.velocity = JumpInCurrentDirection(jump);
        }else if(isOnTheGround){
            _rigidbody.velocity = movement;
        }
    }

    public void RotatePlayer(Vector3 movement){
		if (movement != Vector3.zero){
			characterBody.transform.rotation = Quaternion.Slerp(
				characterBody.transform.rotation, Quaternion.LookRotation(movement), turningSpeed);
		}
	}

    private void PositionFeet(){
        RightFoot.position = FindPosition(Quaternion.AngleAxis(feetAngle, characterBody.transform.forward) * characterBody.transform.up);
        LeftFoot.position = FindPosition(Quaternion.AngleAxis(feetAngle, -characterBody.transform.forward) * characterBody.transform.up);
    }

    private Vector3 FindPosition(Vector3 direction){
        RaycastHit hit;
        var rightRay = new Ray(transform.position, direction);
        Debug.DrawRay(transform.position, direction, Color.cyan);
        if(Physics.Raycast(rightRay, out hit, MaxLegLength, SkipPlayerMask)){
            return hit.point;
        }
        return direction * MaxLegLength;;
    }

	private bool IsGrounded(){
		var ray = new Ray(gameObject.transform.position, Vector3.down);
		return Physics.Raycast(ray, jumpThreashold);
	}

    private Vector3 JumpInCurrentDirection(float jump){
        return new Vector3(_rigidbody.velocity.x, jump, _rigidbody.velocity.z);
    }

    private float FindStandingThreashold(){
		var ray = new Ray(gameObject.transform.position, Vector3.down);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 4)){
            return Vector3.Distance(gameObject.transform.position, hit.point);;
        }
        return -1f;
    }
}
