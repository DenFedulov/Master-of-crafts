using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour {

	private static Cave instance;
	public static Cave Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Cave> ();
			}
			return instance;
		}
	}
}
