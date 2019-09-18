using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;


[CreateAssetMenu(fileName = "Item",menuName = "Item")]
public class Item : ScriptableObject
{
	public string Name;

	public Sprite icon;

	[SerializeField]
	private GameObject itemPref;

	[SerializeField]
	private int id;

	private SlotScript slot;

	public GameObject ItemPref {
		get {
			return itemPref;
		}
		set {
			itemPref = value;
		}
	}

	public int Id {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	protected SlotScript Slot {
		get {
			return slot;
		}
		set {
			slot = value;
		}
	}
}
