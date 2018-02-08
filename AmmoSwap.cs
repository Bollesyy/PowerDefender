using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSwap : MonoBehaviour {

	public enum ammoTypes
	{
		greenAmmo,
		redAmmo,
		blueAmmo,
	};
		
	public ammoTypes ammoType;
	public int ammoNum;

	void Start () {
		ammoNum = 0;
	}
		
	public int Swap(){
		if (ammoNum == 0) {
			ammoType = ammoTypes.greenAmmo;
		} 
		if (ammoNum == 1) {
			ammoType = ammoTypes.blueAmmo;
		} 
		if (ammoNum == 2) {
			ammoType = ammoTypes.redAmmo;
		} 
		if (ammoNum > 2) {
			ammoNum = 0;
			ammoType = ammoTypes.greenAmmo;
		}return ammoNum;
	} 
		
}

	


