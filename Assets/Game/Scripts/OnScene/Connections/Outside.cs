using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside : MonoBehaviour {

	private static Outside instance;
	public static Outside Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Outside> ();
			}
			return instance;
		}
	}
}
