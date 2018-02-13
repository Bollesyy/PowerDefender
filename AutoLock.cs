using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLock : MonoBehaviour {


	public static GameObject[] enemyObjects;
	public bool hasPowerUp;
	public float dropRate = 50f;
	private GameObject target;
	private int rand;
	public int ammoCount;

	void Start(){
		ammoCount = 5;
		hasPowerUp = false;
	}

	void Update () {
		if (enemyObjects == null) {
			Debug.Log ("enemies cleared");
		}
		if (target == null) {
			InitializeTarget ();
		}
		FindTarget ();
		if (Input.GetKeyDown("space") && enemyObjects.Length != 0) {
			DestroyTarget ();
			ammoCount--;
			Debug.Log("Ammo Count: " + ammoCount.ToString());
		}
		if (Input.GetKeyDown("q")  && hasPowerUp && enemyObjects.Length != 0) {
			DestroyAllEnemies ();
			hasPowerUp = false;
			Debug.Log ("No more powerUp");
		}
		if (ammoCount == 0) {
			StartCoroutine(Reload ());
		}
	}

	void LateUpdate(){
		enemyObjects = GameObject.FindGameObjectsWithTag ("EnemyTargets"); //Adds each enemy to an array of enemy GameObjects
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
		Debug.Log ("Target destroyed");
		DropPowerUp ();
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

	IEnumerator Reload(){
		Debug.Log ("Reloading");
		yield return new WaitForSeconds (2);
		Debug.Log ("Reloaded");
		ammoCount = 5;
	}
}
