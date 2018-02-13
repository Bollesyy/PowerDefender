using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Hallway2TargetEnable : MonoBehaviour {

	private int target;
	public static Collider collider2;
	void Start () {
		collider2 = GetComponent<BoxCollider> ();
		target = FirstPersonController.TargetsCurrent;
	}

	// Update is called once per frame
	void Update () {
		target = FirstPersonController.TargetsCurrent;
		if (target == 1 ) {
			collider2.enabled = true;
			Debug.Log ("Hallway2 Engaged");
		} else if (target != 1) {
			collider2.enabled = false;
			Debug.Log ("Disengaged Hallway2");
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name.Contains ("Enemy")) {
			if (collider2.enabled) {
				col.gameObject.tag = "EnemyTargets";
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		for (int i = 0; i < AutoLock.enemyObjects.Length; i++) {
			AutoLock.enemyObjects [i] = null;
		}


	}
}
