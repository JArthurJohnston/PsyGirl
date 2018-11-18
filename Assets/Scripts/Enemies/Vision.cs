using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

	public GameObject body;

	public Vector3 playerPosition {get; set;}

	Animator animator;

	public bool canSeePlayer {get; private set;}

	// Use this for initialization
	void Start () {
		animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
		canSeePlayer = false;
		playerPosition = Vector3.zero;
	}

	void OnTriggerEnter(Collider collider){
		var ray = new Ray(body.transform.position, collider.transform.position - body.transform.position);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, 100f, allBut(LayerMask.NameToLayer("EnemyVision")))){
			if(hit.collider.gameObject.tag =="Player"){
				canSeePlayer = true;
				playerPosition = collider.transform.position;
				animator.SetBool(EnemyState.CAN_SEE_PLAYER, true);
			}
		}
	}

	void OnTriggerStay(Collider collider){
		if(canSeePlayer && collider.gameObject.tag =="Player"){
			playerPosition = collider.transform.position;
		}
	}

	void OnTriggerExit(Collider collider){
		canSeePlayer = false;
	}

	//raycast layermask helpers
	int allBut(int layerId){
		return ~(only(layerId)); 
	}

	int only(int layerId){
		return 1 << layerId;
	}
}
