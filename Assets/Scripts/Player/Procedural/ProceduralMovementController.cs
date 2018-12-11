using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMovementController : MonoBehaviour {

    public float turningSpeed;
    public GameObject characterBody;
    public float jumpThreashold = 1;

    private Rigidbody _rigidbody;
    void Start(){
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement, float jump){
        var isOnTheGround = IsGrounded();
        RotatePlayer(movement);
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

	private bool IsGrounded(){
		var ray = new Ray(gameObject.transform.position, Vector3.down);
		RaycastHit hit;
		return Physics.Raycast(ray, jumpThreashold);
	}

    private Vector3 JumpInCurrentDirection(float jump){
        return new Vector3(_rigidbody.velocity.x, jump, _rigidbody.velocity.z);
    }
}
