using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	[Header("Set in Inspector")]

	public GameObject enemy;                
	public float spawnTime = 3f;            
	public Transform[] spawnPoints;

	void Start () {
		//Calls Spawn function after a delay and repeats after same time frame
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn(){
		//Chooses a random spawnPoint
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		//Spawns enemy at spawnPointIndex
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}



	
	
}
