using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public bool Play = false;
	public Sprite SPlay, SPlay2;

	void OnMouseEnter()
	{
		GetComponent<SpriteRenderer> ().sprite = SPlay2;
	}

	void OnMouseExit()
	{
		GetComponent<SpriteRenderer> ().sprite = SPlay;
	}

	void OnMouseUp()
	{
		if (Play == true) {
			SceneManager.LoadScene (1);
		}
	}
}
