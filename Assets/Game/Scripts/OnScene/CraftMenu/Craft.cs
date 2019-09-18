using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Craft : MonoBehaviour, IPointerClickHandler
{
	public CombineMenu CB;

	public bool Success;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
			//CRAFTING REPICES
			if (ContextValues.Instance.ContSlot != null && !CB.gameObject.activeInHierarchy) {
				//Debug.Log ("ContV slot = null, CB slots <= 0");
				Success = false;
				//6StoneAxeHead-1
				if (MoveItem.Instance.TakenItem.Id == 3 && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (3, 3, 1, 
							3, 3, 1, 
							3, 3, 1,
							6);
				}
				//6StoneAxeHead-2
				if (MoveItem.Instance.TakenItem.Id == 3 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (1, 3, 3, 
							1, 3, 3, 
							1, 3, 3,
							6);
				}
				//3StoneChisel-1
				if (MoveItem.Instance.TakenItem.Id == 1 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (0, 0, 0,
							1, 3, 3,
							0, 0, 0,
							3);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Chisel);
				}
				//3StoneChisel-2
				if (MoveItem.Instance.TakenItem.Id == 1 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (0, 0, 0,
							3, 3, 1,
							0, 0, 0,
							3);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Chisel);
				}
				//3StoneChisel-3
				if (MoveItem.Instance.TakenItem.Id == 1 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (0, 1, 0,
							0, 3, 0,
							0, 3, 0,
							3);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Chisel);
				}
				//3StoneChisel-4
				if (MoveItem.Instance.TakenItem.Id == 1 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (0, 3, 0,
							0, 3, 0,
							0, 1, 0,
							3);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Chisel);
				}
				//4GoodStick-1
				if (MoveItem.Instance.TakenItem.Id == 3 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 2) {
					Repice (0, 0, 0,
							2, 2, 2,
							0, 0, 0,
							4);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.GoodSt);
				}
				//4GoodStick-2
				if (MoveItem.Instance.TakenItem.Id == 3 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 2) {
					Repice (0, 2, 0,
							0, 2, 0,
							0, 2, 0,
							4);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.GoodSt);
				}
				//11PolishedStone
				if (MoveItem.Instance.TakenItem.Id == 3 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 1) {
					Repice (1, 1, 1,
							1, 1, 1,
							1, 1, 1,
							11);
				}
				//14ClayPotWet
				if (MoveItem.Instance.TakenItem.Id == 1 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 13) {
					Repice (3, 3, 3,
							3, 1, 3,
							3, 3, 3,
							14);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Pot);
				}
				//22Plank-1
				if (MoveItem.Instance.TakenItem.Id == 21 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 2) {
					Repice (0, 2, 0,
							0, 2, 0,
							0, 2, 0,
							22);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Plak);
				}
				//22Plank-2
				if (MoveItem.Instance.TakenItem.Id == 21 && !ContextValues.Instance.ContSlot.IsEmpty && ContextValues.Instance.ContSlot.Items.Peek ().Id == 2) {
					Repice (0, 0, 0,
							2, 2, 2,
							0, 0, 0,
							22);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Plak);
				}
				//Fail
				if (CraftMenu.Instance.AreTargetsFull == false && Success == false) {
					ContextValues.Instance.ContSlot.RemoveItem ();
					MenuClose.Instance.Close ();
				}
			}
			//MATERIAL HARVEST REPICES
			if (MoveItem.Instance.TakenItem != null && ContextValues.Instance.MaterialHarvest != 0) {
				//5WoodRind-1
				if (MoveItem.Instance.TakenItem.Id == 3 && ContextValues.Instance.MaterialHarvest == 1) {
					Repice (3, 0, 3,
							3, 0, 3,
							3, 0, 3,
							5);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.WoodRind);
				}
				//5WoodRind-2
				if (MoveItem.Instance.TakenItem.Id == 3 && ContextValues.Instance.MaterialHarvest == 1) {
					Repice (0, 3, 3,
							0, 3, 3,
							0, 3, 3,
							5);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.WoodRind);
				}
				//5WoodRind-3
				if (MoveItem.Instance.TakenItem.Id == 3 && ContextValues.Instance.MaterialHarvest == 1) {
					Repice (3, 3, 0,
							3, 3, 0,
							3, 3, 0,
							5);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.WoodRind);
				}
				//2Stick
				if (MoveItem.Instance.TakenItem.Id == 7 && ContextValues.Instance.MaterialHarvest == 1) {
					Repice (0, 0, 0,
							3, 3, 3,
							3, 3, 3,
							2);
				}
				//13Clay
				if (MoveItem.Instance.TakenItem.Id == 12 && ContextValues.Instance.MaterialHarvest == 2) {
					Repice (0, 0, 0,
							0, 3, 0,
							0, 0, 0,
							13);
					if (Success) {
						PitScript.Instance.WaterIn -= 50;
						TipManager.Instance.AddTip (TipManager.Instance.Cl);
					}
				}
				//17IronOre
				if (MoveItem.Instance.TakenItem.Id == 7 && ContextValues.Instance.MaterialHarvest == 3) {
					Repice (0, 0, 0,
							0, 3, 0,
							0, 0, 0,
							17);
					if (Success)
						TipManager.Instance.AddTip (TipManager.Instance.Ore);
				}
				//1Stone
				if (MoveItem.Instance.TakenItem.Id == 7 && ContextValues.Instance.MaterialHarvest == 3) {
					for(int i = 0;i<3;i++)
					Repice (0, 0, 0,
							0, 0, 0,
							0, 0, 0,
							1);
				}
				//2Stick
				if (MoveItem.Instance.TakenItem.Id == 21 && ContextValues.Instance.MaterialHarvest == 1) {
					for(int i = 0;i<3;i++)
					Repice (0, 0, 0,
							3, 3, 3,
							3, 3, 3,
							2);
				}
			}
			//COMBINE REPICES
			if (CB.gameObject.activeInHierarchy) {
				//7StoneAxe
				Combine (4, 6, 5, 
					AllItems.Instance.ItemsArray [7].ItemPref);
				//7StoneAxe-2
				Combine (6, 4, 5, 
					AllItems.Instance.ItemsArray [7].ItemPref);
				//8Campfire-1
				Combine (2, 2, 2, 2, 4, 5,
					AllItems.Instance.ItemsArray [8].ItemPref);
				//8Campfire-2
				Combine (2, 2, 2, 2, 5, 4,
					AllItems.Instance.ItemsArray [8].ItemPref);
				//8Campfire-3
				Combine (4, 5, 2, 2, 2, 2,
					AllItems.Instance.ItemsArray [8].ItemPref);
				//8Campfire-4
				Combine (5, 4, 2, 2, 2, 2,
					AllItems.Instance.ItemsArray [8].ItemPref);
				//9FireStick-1
				Combine (4, 4, 5,
					AllItems.Instance.ItemsArray [9].ItemPref);
				//9FireStick-2
				Combine (4, 5, 4,
					AllItems.Instance.ItemsArray [9].ItemPref);
				//12StoneShovel
				Combine (4, 11, 5, 
					AllItems.Instance.ItemsArray [12].ItemPref);
				//12StoneShovel-2
				Combine (11, 4, 5, 
					AllItems.Instance.ItemsArray [12].ItemPref);
				//19MoldIronAxeHead
				Combine (13, 6, 17, 
					AllItems.Instance.ItemsArray [19].ItemPref);
				//21IronAxe-1
				Combine (4, 20, 
					AllItems.Instance.ItemsArray [21].ItemPref);
				//21IronAxe-2
				Combine (20, 4,  
					AllItems.Instance.ItemsArray [21].ItemPref);
				//23Ladder
				Combine (22, 22, 22, 22, 22, 22,
					AllItems.Instance.ItemsArray [23].ItemPref);
			}
        }
    }

    public void Repice(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int item)
    {
		bool[] TrgCheck = new bool[9];
        foreach (Target trg in CraftMenu.Instance.targets)
        {
            if (trg.TargetId == 1 && trg.HitPoints == i1)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 2 && trg.HitPoints == i2)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 3 && trg.HitPoints == i3)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 4 && trg.HitPoints == i4)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 5 && trg.HitPoints == i5)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 6 && trg.HitPoints == i6)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 7 && trg.HitPoints == i7)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 8 && trg.HitPoints == i8)
                TrgCheck[trg.TargetId - 1] = true;
            if (trg.TargetId == 9 && trg.HitPoints == i9)
                TrgCheck[trg.TargetId - 1] = true;
            if (TrgCheck[0] && TrgCheck[1] && TrgCheck[2] && TrgCheck[3] && TrgCheck[4] && TrgCheck[5] && TrgCheck[6] && TrgCheck[7] && TrgCheck[8])
            {
				Success = true;
				if (ContextValues.Instance.ContSlot != null && !ContextValues.Instance.ContSlot.IsEmpty)
					ContextValues.Instance.ContSlot.RemoveItem();
				InventoryScript.Instance.AddOrDrop (item);
                MenuClose.Instance.Close();
            }
        }
    }
	//combine2
	public void Combine(int i1, int i2,GameObject pref){
		List<SlotScript> withItem = new List<SlotScript>();
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			if (slot.Items.Count > 0)
				withItem.Add (slot);
		}
		bool[] Order = new bool[6];
		int i = 0;
		if (withItem.Count > 0) {
			foreach (SlotScript itemSlot in withItem) {
				i++;
				itemSlot.SlotId = i;
				if (itemSlot.Items.Peek ().Id == i1 && itemSlot.SlotId == 1)
					Order [0] = true;
				if (itemSlot.Items.Peek ().Id == i2 && Order [0] && itemSlot.SlotId == 2)
					Order [1] = true;
				if (Order [0] && Order [1]) {
					AllItems.Instance.Drop(pref);
					CombineClose.Instance.Close ();
				}
			}
		}
	}
	//combine3
	public void Combine(int i1, int i2, int i3,GameObject pref){
		List<SlotScript> withItem = new List<SlotScript>();
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			if (slot.Items.Count > 0)
				withItem.Add (slot);
		}
		bool[] Order = new bool[6];
		int i = 0;
		if (withItem.Count > 0) {
			foreach (SlotScript itemSlot in withItem) {
				i++;
				itemSlot.SlotId = i;
				if (itemSlot.Items.Peek ().Id == i1 && itemSlot.SlotId == 1)
					Order [0] = true;
				if (itemSlot.Items.Peek ().Id == i2 && Order [0] && itemSlot.SlotId == 2)
					Order [1] = true;
				if (itemSlot.Items.Peek ().Id == i3 && Order [1] && itemSlot.SlotId == 3)
					Order [2] = true;
				if (Order [0] && Order [1] && Order [2]) {
					AllItems.Instance.Drop(pref);
					CombineClose.Instance.Close ();
				}
			}
		}
	}
	//combine4
	public void Combine(int i1, int i2, int i3, int i4, GameObject pref){
		List<SlotScript> withItem = new List<SlotScript>();
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			if (slot.Items.Count > 0)
				withItem.Add (slot);
		}
		bool[] Order = new bool[6];
		int i = 0;
		if (withItem.Count > 0) {
			foreach (SlotScript itemSlot in withItem) {
				i++;
				itemSlot.SlotId = i;
				if (itemSlot.Items.Peek ().Id == i1 && itemSlot.SlotId == 1)
					Order [0] = true;
				if (itemSlot.Items.Peek ().Id == i2 && Order [0] && itemSlot.SlotId == 2)
					Order [1] = true;
				if (itemSlot.Items.Peek ().Id == i3 && Order [1] && itemSlot.SlotId == 3)
					Order [2] = true;
				if (itemSlot.Items.Peek ().Id == i4 && Order [2] && itemSlot.SlotId == 4)
					Order [3] = true;
				if (Order [0] && Order [1] && Order [2] && Order [3]) {
					AllItems.Instance.Drop(pref);
					CombineClose.Instance.Close ();
				}
			}
		}
	}
	//combine5
	public void Combine(int i1, int i2, int i3, int i4, int i5, GameObject pref){
		List<SlotScript> withItem = new List<SlotScript>();
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			if (slot.Items.Count > 0)
				withItem.Add (slot);
		}
		bool[] Order = new bool[6];
		int i = 0;
		if (withItem.Count > 0) {
			foreach (SlotScript itemSlot in withItem) {
				i++;
				itemSlot.SlotId = i;
				if (itemSlot.Items.Peek ().Id == i1 && itemSlot.SlotId == 1)
					Order [0] = true;
				if (itemSlot.Items.Peek ().Id == i2 && Order [0] && itemSlot.SlotId == 2)
					Order [1] = true;
				if (itemSlot.Items.Peek ().Id == i3 && Order [1] && itemSlot.SlotId == 3)
					Order [2] = true;
				if (itemSlot.Items.Peek ().Id == i4 && Order [2] && itemSlot.SlotId == 4)
					Order [3] = true;
				if (itemSlot.Items.Peek ().Id == i5 && Order [3] && itemSlot.SlotId == 5)
					Order [4] = true;
				if (Order [0] && Order [1] && Order [2] && Order [3] && Order [4]) {
					AllItems.Instance.Drop(pref);
					CombineClose.Instance.Close ();
				}
			}
		}
	}
	//combine6
	public void Combine(int i1, int i2, int i3, int i4, int i5, int i6, GameObject pref){
		List<SlotScript> withItem = new List<SlotScript>();
		foreach (SlotScript slot in CombineMenu.Instance.CombSlots) {
			if (slot.Items.Count > 0)
				withItem.Add (slot);
		}
		bool[] Order = new bool[6];
		int i = 0;
		if (withItem.Count > 0) {
			foreach (SlotScript itemSlot in withItem) {
				i++;
				itemSlot.SlotId = i;
				if (itemSlot.Items.Peek ().Id == i1 && itemSlot.SlotId == 1)
					Order [0] = true;
				if (itemSlot.Items.Peek ().Id == i2 && Order [0] && itemSlot.SlotId == 2)
					Order [1] = true;
				if (itemSlot.Items.Peek ().Id == i3 && Order [1] && itemSlot.SlotId == 3)
					Order [2] = true;
				if (itemSlot.Items.Peek ().Id == i4 && Order [2] && itemSlot.SlotId == 4)
					Order [3] = true;
				if (itemSlot.Items.Peek ().Id == i5 && Order [3] && itemSlot.SlotId == 5)
					Order [4] = true;
				if (itemSlot.Items.Peek ().Id == i6 && Order [4] && itemSlot.SlotId == 6)
					Order [5] = true;
				if (Order [0] && Order [1] && Order [2] && Order [3] && Order [4] && Order [5]) {
					AllItems.Instance.Drop(pref);
					CombineClose.Instance.Close ();
				}
			}
		}
	}
}
