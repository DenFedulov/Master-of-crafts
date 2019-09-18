using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	private static InventoryScript instance;
	public static InventoryScript Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<InventoryScript> ();
			}
			return instance;
		}
	}

	public GameObject slotPref;

	public List<SlotScript> Inventory = new List<SlotScript>();

	public List<int> InventoryItemsIds = new List<int>();

	public SaveLoad MySaveLoad;

	//DEBUG VARIABALES
	//public int slotcount = 0;
	//public bool empty;
	//public int MaxItem = 0;


	public void AddSlots()
	{
		Inventory = new List<SlotScript> ();
		for (int i = 0; i < 10; i++) {
			SlotScript slot = Instantiate (slotPref, transform).GetComponent<SlotScript> ();
			Inventory.Add (slot);
		}
	}

	public bool AddItem(Item item)
	{
		foreach (SlotScript slot in Inventory) {
			if (slot.IsEmpty) {
				slot.AddItem (item);
				return true;
			}
		}
		return false;
	}

	public void RefreshItemList()
	{
		InventoryItemsIds = new List<int> ();
		foreach (SlotScript slot in Inventory) {
			if (!slot.IsEmpty) {
				InventoryItemsIds.Add (slot.Items.Peek ().Id);
			}
		}
	}

	public bool IsAnySlotEmpty
	{
		get {
			foreach (SlotScript slot in Inventory) {
			if (slot.IsEmpty)
				return true;
			}
			return false;
		}
	}

	public bool IsItemsEmpty
	{
		get {
			if (Inventory.Count > 0) {
				return false;
			} else {
				return true;
			}
		}
	}

	public void AddOrDrop(int item)
	{
		if (IsAnySlotEmpty)
			AddItem (AllItems.Instance.ItemsArray [item]);
		else
			AllItems.Instance.Drop (AllItems.Instance.ItemsArray [item].ItemPref);
	}

	void Start()
	{
		AddSlots ();
	}

	void Update()
	{
		//empty = IsAnySlotEmpty;
        if (Input.GetMouseButtonUp(0))
        {
            Activator.Instance.TurnOff();
        }
	}

	public void ClearInv()
	{
		foreach (SlotScript slot in Inventory) {
			Destroy (slot.gameObject);
		}
	}

}
