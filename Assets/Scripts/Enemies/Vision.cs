using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

	public GameObject body;
	GameObject player;
	Patrol patrol;

	EnemyController controller;

	bool canSeePlayer;

	// Use this for initialization
	void Start () {
		patrol = transform.parent.gameObject.GetComponent<Patrol>();
		controller = transform.parent.gameObject.GetComponent<EnemyController>();
		player = GameObject.FindGameObjectWithTag("Player");
		if(player == null){
			Debug.Log("Cant find a player!!!");
		}
		canSeePlayer = false;
	}

	void Update(){
		if(canSeePlayer){
			patrol.stopMoving();
			controller.facePlayer();
		} else {
			patrol.startMoving();
		}
	}

	const int VISIBLE_LAYER = 11;
	const int ENEMY_VISION = 10;

	void OnTriggerEnter(Collider collider){
		var ray = new Ray(body.transform.position, player.transform.position - body.transform.position);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100f, allBut(ENEMY_VISION))){
			if(hit.collider.gameObject.tag =="Player"){
				canSeePlayer = true;
			}
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
