using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[Header("Set in Inspector")]
	public GameObject player;
	public float speed;

	void FixedUpdate(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
	}
	

}
