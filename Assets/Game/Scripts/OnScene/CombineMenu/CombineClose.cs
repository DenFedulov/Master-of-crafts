using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombineClose : MonoBehaviour, IPointerClickHandler {

	public GameObject menu;

	public void Close()
	{
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			Destroy (slot.gameObject);
		}
		menu.SetActive (false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			bool HaveItem = false;
			foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
				if (slot.Items.Count > 0)
					HaveItem = true;
			}
			if (HaveItem == false) 
				Close ();
		}
	}

	private static CombineClose instance;
	public static CombineClose Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<CombineClose>();
			}
			return instance;
		}
	}
}
