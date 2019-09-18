using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenuOpen : MonoBehaviour {

	public GameObject Cmenu,ImageItem;

	private static CraftMenuOpen instance;
	public static CraftMenuOpen Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<CraftMenuOpen>();
			}
			return instance;
		}
	}

	public void OpenCraftMenu()
	{
		if (ContextValues.Instance.ContSlot != null && !ContextValues.Instance.ContSlot.IsEmpty || ContextValues.Instance.MaterialHarvest != 0 && MoveItem.Instance.TakenItem != null)
		{
			Cmenu.SetActive(true);
			CraftMenu.Instance.AddTargets();
			ImageItem.GetComponent<Image> ().sprite = null;
			var t = ImageItem.GetComponent<Image> ().color;
			t.a = 0f;
			ImageItem.GetComponent<Image> ().color = t;
			if (ContextValues.Instance.ContSlot != null) {
				if (!ContextValues.Instance.ContSlot.IsEmpty) {
					ImageItem.GetComponent<Image> ().sprite = ContextValues.Instance.ContSlot.Items.Peek ().icon;
					ImageItem.GetComponent<RectTransform> ().sizeDelta = new Vector2 (ContextValues.Instance.ContSlot.Items.Peek ().icon.rect.width * 1.5f, ContextValues.Instance.ContSlot.Items.Peek ().icon.rect.height * 1.5f);
					t = ImageItem.GetComponent<Image> ().color;
					t.a = 255f;
					ImageItem.GetComponent<Image> ().color = t;
				}
			}
		}
	}
}
