using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource Aud;
	public AudioClip Cl;

	void Start () {
		Aud.clip = Cl;
		Aud.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
