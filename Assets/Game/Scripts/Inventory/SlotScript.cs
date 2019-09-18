using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour,IPointerClickHandler  {

	private static SlotScript instance;
	public static SlotScript Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<SlotScript> ();
			}
			return instance;
		}
	}

	public int SlotId = 0;

	private Stack<Item> items = new Stack<Item>();

	public int IdItemSlot = 0;

	public Stack<Item> Items {
		get {
			return items;
		}
		set {
			items = value;
		}
	}

	[SerializeField]
	private Image icon;

	public Image Icon {
		get {
			return icon;
		}
		set {
			icon = value;
		}
	}

	public InventoryScript conn { get; set;}

	public bool AddItem(Item item)
	{
		items.Push (item);
		icon.sprite = item.icon;
        icon.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(item.icon.rect.width/4, item.icon.rect.height/4);
		icon.color = Color.white;
		InventoryScript.Instance.RefreshItemList ();
		if(item.Id == 7)
			TipManager.Instance.AddTip (TipManager.Instance.StAxe);
		if(item.Id == 21)
			TipManager.Instance.AddTip (TipManager.Instance.IrAxe);
		if(item.Id == 12)
			TipManager.Instance.AddTip (TipManager.Instance.Shov);
		/*InventoryScript.Instance.Items[InventoryScript.Instance.MaxItem] = item.Id;
		IdItemSlot = InventoryScript.Instance.MaxItem + 1;
		InventoryScript.Instance.MaxItem++;*/
		//Debug.Log (InventoryScript.Instance.Items [InventoryScript.Instance.MaxItem]);
		return true;  
	}

	public bool RemoveItem()
	{
		/*if (items.Count > 0 && IdItemSlot != 0) {
			InventoryScript.Instance.MaxItem -= 1;
			for (int i = IdItemSlot; i < 10; i++) {
				InventoryScript.Instance.Items [i - 1] = InventoryScript.Instance.Items [i];
			}
			Debug.Log ("Slot " + IdSlot + " deteted");
			IdItemSlot = 0;*/
			items.Pop ();
			icon.sprite = null;
			var tcolor = icon.color;
			tcolor.a = 0f;
			icon.color = tcolor;
		InventoryScript.Instance.RefreshItemList ();
		return true;
	}
		
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
            if (MoveItem.Instance.TakenItem == null)
                {
                    if (!IsEmpty)
                    {
                        MoveItem.Instance.TakenItem = items.Peek();
                        MoveItem.Instance.IconSet(Items.Peek().icon);
                        RemoveItem();
                    }
                }
                else
                {
                    if (IsEmpty)
                    {
                        MoveItem.Instance.IconRem();
                        AddItem(MoveItem.Instance.TakenItem);
                        MoveItem.Instance.TakenItem = null;
                    }
                    else
                    {
                        Item Titem = MoveItem.Instance.TakenItem;
                        MoveItem.Instance.IconSet(Items.Peek().icon);
                        MoveItem.Instance.TakenItem = items.Peek();
                        RemoveItem();
                        AddItem(Titem);
                    }
                }
		}
		if (eventData.button == PointerEventData.InputButton.Right) {
			//RemoveItem ();
            Activator.Instance.TurnOn();
            ContextValues.Instance.ContSlot = GetComponent<SlotScript>();
		}
	}

	//public Item GetItem ()
	//{
	//		return items.Peek ();
	//}

	public bool IsEmpty
	{
		get {return items.Count == 0;}
	} 

	public void Initialize(InventoryScript conn)
	{
		this.conn = conn;
	}
}
