using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMenu : MonoBehaviour {

	public List<SlotScript> CombSlots;

	public GameObject slotPref;

	public void AddCombineSlots()
	{
		CombSlots = new List<SlotScript>();
		for (int i = 0; i < 6; i++)
		{
			SlotScript slot = Instantiate(slotPref, transform).GetComponent<SlotScript>();
			slot.SlotId = i + 1;
			CombSlots.Add(slot);
		}
	}

	private static CombineMenu instance;
	public static CombineMenu Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<CombineMenu>();
			}
			return instance;
		}
	}
}
