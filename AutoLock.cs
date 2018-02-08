using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLock : MonoBehaviour {


	public GameObject[] enemyObjects;
	public bool hasPowerUp;
	public float dropRate = 50f;
	private GameObject target;
	private int rand;

	void Start(){
		hasPowerUp = false;
	}

	void Update () {
		if (target == null) {
			InitializeTarget ();
		}
		FindTarget ();
		if (Input.GetKeyDown("space") && enemyObjects.Length != 0) {
			DestroyTarget ();
			DropPowerUp ();
		}
		if (hasPowerUp && Input.GetKeyDown("q")) {
			DestroyAllEnemies ();
			hasPowerUp = false;
			Debug.Log ("No more powerUp");
		}
	}

	void LateUpdate(){
		enemyObjects = GameObject.FindGameObjectsWithTag ("Enemy"); //Adds each enemy to an array of enemy GameObjects
	}
		
	void FindTarget(){
		foreach (GameObject go in enemyObjects) {
			if (Vector3.Distance (transform.position, go.transform.position) < Vector3.Distance (transform.position, target.transform.position)) {
				target = go;
			} 
		}
	}

	void InitializeTarget(){
		if (enemyObjects.Length == 0) {
			return;
		} 
			target = enemyObjects [0];
	}

	void DestroyTarget(){
		Destroy (target);
	}

	public bool DropPowerUp(){
		rand = Random.Range (0, 100);
		if (rand < dropRate) {
			hasPowerUp = true;
			Debug.Log ("Has PowerUp");
		}return hasPowerUp;
	}

	void DestroyAllEnemies(){
		enemyObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemyObjects.Length; i++) {
			Destroy (enemyObjects[i]);
		}

	}
}
