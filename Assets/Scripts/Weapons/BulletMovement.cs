using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float Lifespan;
    public float Speed;

    void Start() {
		GetComponent<Rigidbody>().velocity = transform.forward * Speed;
		Destroy(gameObject, Lifespan);
	}
}