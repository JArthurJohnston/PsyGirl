using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public void FireFrom(Transform origin, float damage){
		var bullet = Instantiate(this, origin.position, origin.rotation).GetComponent<BulletDamage>();
		bullet.Damage = damage;
    }
}