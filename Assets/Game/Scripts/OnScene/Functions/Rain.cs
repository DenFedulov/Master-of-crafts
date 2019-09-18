using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain : MonoBehaviour {

	public float RainTimer = 0;
	public bool IsRaining;
	public Sprite RainSprite,MainSprite;
	int t = 120;

	void Update () {
		if (RainTimer < t && IsRaining == false)
			RainTimer += Time.deltaTime;
		if (RainTimer >= t && IsRaining == false) 
			StartRain ();
		if (RainTimer < t && IsRaining)
			RainTimer += Time.deltaTime;
		if (RainTimer >= t && IsRaining)
			StopRain ();
	}

	public void StartRain()
	{
		GetComponent<Image> ().sprite = RainSprite;
		IsRaining = true;
		t = 30;
		RainTimer = 0;
	}

	public void StopRain()
	{
		GetComponent<Image> ().sprite = MainSprite;
		IsRaining = false;
		t = 120;
		RainTimer = 0;
	}

	private static Rain instance;
	public static Rain Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Rain> ();
			}
			return instance;
		}
	}
}
