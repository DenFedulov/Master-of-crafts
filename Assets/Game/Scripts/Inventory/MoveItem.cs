using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveItem : MonoBehaviour {

	private static MoveItem instance;
	public static MoveItem Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<MoveItem> ();
			}
			return instance;
		}
	}

	public Item TakenItem;

	public void IconSet(Sprite icon)
	{
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(icon.rect.width / 4, icon.rect.height / 4);
		gameObject.GetComponent<Image> ().sprite = icon;
		gameObject.GetComponent<Image> ().color = Color.white;
	}

	public void IconRem()
	{
		gameObject.GetComponent<Image> ().sprite = null;
		var tempc = gameObject.GetComponent<Image> ().color;
		tempc.a = 0f;
		gameObject.GetComponent<Image> ().color = tempc;
		gameObject.transform.position = new Vector3 (-41,-172+400, 0);
	}

	void Update () {
		if (TakenItem != null) {
        gameObject.transform.position = Input.mousePosition;
		}
	}
}
