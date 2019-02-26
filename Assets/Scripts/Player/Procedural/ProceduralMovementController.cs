using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMovementController : MonoBehaviour {

    public float turningSpeed;
    public GameObject characterBody;
    private Rigidbody _rigidbody;
    public float feetAngle = 3f;
    public Transform RightFoot;
    public Transform LeftFoot;
    public float MaxLegLength = 4f;
    private int SkipPlayerMask;
    public float rotationMultiplier;

    void Start(){
        SkipPlayerMask = RayHelper.allButLayerMask("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement, float jump){
        
        var isOnTheGround = IsTouchingTheGround();
        RotatePlayer(movement);
        PositionFeet();
        if(jump > 0 && isOnTheGround){
            _rigidbody.velocity = JumpInCurrentDirection(jump);
        }else if(isOnTheGround){
            _rigidbody.velocity = movement;
            // ApplyTilt(movement);
        }
    }

    public void ApplyTilt(Vector3 movement){
        Vector3 speedBasedTilt = movement * rotationMultiplier;
        characterBody.transform.rotation = Quaternion.Euler(speedBasedTilt.x, gameObject.transform.rotation.y, speedBasedTilt.z);
    }

    public void RotatePlayer(Vector3 movement) {
		if (movement != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(movement);
            // Quaternion currentRotation = characterBody.transform.rotation;
            // Quaternion tiltRotation = Quaternion.Euler(characterBody.transform.forward * rotationMultiplier);

            // Debug.Log(_rigidbody.velocity);
            // Quaternion rot = tiltRotation * lookRotation;

            var movingSpeed = Mathf.Max(_rigidbody.velocity.x, _rigidbody.velocity.z);


			characterBody.transform.rotation = Quaternion.Slerp(
				characterBody.transform.rotation, lookRotation, turningSpeed);
            characterBody.transform.Rotate(movingSpeed, 0, 0);
            // characterBody.transform.Rotate(Vector3.right * _rigidbody.velocity.forward * rotationMultiplier);

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
        if(Physics.Raycast(rightRay, out hit, MaxLegLength * 2, SkipPlayerMask)){
            return hit.point;
        }
        return transform.position + direction * MaxLegLength;
    }

	private bool IsGrounded(){
        return _rigidbody.velocity.y == 0;
	}

    private bool IsTouchingTheGround() {
		var ray = new Ray(gameObject.transform.position, Vector3.down);
		RaycastHit hit;
        return Physics.Raycast(ray, out hit, this.MaxLegLength);
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
