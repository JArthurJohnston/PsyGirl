using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void holdGun(){

	}

	public void dropGun(){
		
	}
	
	public void facePlayer(){
		transform.LookAt(player.transform);
	}
}
