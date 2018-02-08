using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoSwap : AmmoSwap {
	
	void Update () {
		if (Input.GetKeyDown ("a")) {
			Invoke ("Swap", 0);
			ammoNum += 1;
			Debug.Log ("ammoType:" + ammoType.ToString ());
		}
	}
}
