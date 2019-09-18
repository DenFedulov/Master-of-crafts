using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour {

	public float timer = 1;

	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = 1;
			GetComponent<Text> ().text = "";
			gameObject.SetActive (false);
		}
	}
}
