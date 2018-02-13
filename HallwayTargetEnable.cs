using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HallwayTargetEnable : MonoBehaviour {
	
	private int target;
	public static Collider collider1;
	void Start () {
		collider1 = GetComponent<BoxCollider> ();
		target = FirstPersonController.TargetsCurrent;
	}
	
	// Update is called once per frame
	void Update () {
		target = FirstPersonController.TargetsCurrent;
		if (target == 0 ) {
			collider1.enabled = true;
			Debug.Log ("Hallway1 Engaged");
		} else if (target != 0) {
			collider1.enabled = false;
		}
			Debug.Log ("Disengaged Hallway1");
		}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Contains("Enemy")) {
			if (collider1.enabled) {
				col.gameObject.tag = "EnemyTargets";
			}
		}
	}

	void OnTriggerExit(Collider col){
		for (int i = 0; i < AutoLock.enemyObjects.Length; i++) {
			AutoLock.enemyObjects [i] = null;
		}
	}
}


