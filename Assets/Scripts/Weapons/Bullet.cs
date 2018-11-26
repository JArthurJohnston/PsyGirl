using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet {

    public static void FireFrom(Transform origin, float damage){
		var ray = new Ray(origin.position, origin.forward);
		RaycastHit hit;
        //eventually expand this to hit and damage anything that is damagable

        if(Physics.Raycast(ray, out hit, 100f, allBut(LayerMask.NameToLayer("EnemyVision")))){
            //add in some animations for the point where the bullet if fired and where it hits
			if(hit.collider.gameObject.tag =="Player"){
                Player.Resources.Health -= damage;
			}
        }
    }

    static int allBut(int layerId){
		return ~(only(layerId)); 
	}

	static int only(int layerId){
		return 1 << layerId;
	}
}