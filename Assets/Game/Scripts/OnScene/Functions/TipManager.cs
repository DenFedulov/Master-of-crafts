using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TipManager : MonoBehaviour, IPointerClickHandler
{
	public GameObject TipPref,TipParent,TipMenu;

	public List<string> AllTips = new List<string>();

	public string Done = "";
	public string max = "Try to make chisel out of stones!123";

	public string First = "You fall into some random hole. Now you can't get out, or can you? Try to make chisel out of stones!";
	public string Chisel = "You can process sticks, sharpen or make stone slim and harvest rind from roots with chisel."; 
	public string GoodSt = "Processed stick is can be used to make instruments, campfire or fire stick by combining it with other materials.";
	public string WoodRind = "Rind can be used to make instruments or tool to start a fire.";
	public string StAxe = "Axe can be used to harvest wood or even ores from the cave.";
	public string Campfire = "You can cook(right click) some items on the campfire and upgrade it if you manage to get a clay.(use friction to lit it)";
	public string Shov = "You can use shovel to dig hole so it can hold water and dig clay and make it wet by using water from pit.";
	public string Cl = "Clay can be used to upgrade campfire to furnace so it can produce coal from sticks, or make a pot using stone";
	public string Pot = "You need to burn pot on campfire or in furnace before using it.";
	public string Ore = "You can use Iron Ore to make a mold of Iron Axe Head";
	public string IrAxe = "You can use Iron Axe to harvest extra materials or make really good wood";
	public string Plak = "Planks can be used to make a ladder to get out.";



	public void AddTip(string tip)
	{
		if (IsTipFirst (tip)) {
			var t = Instantiate (TipPref, TipParent.transform);
			t.GetComponent<Text> ().text = tip;
			TipParent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (TipParent.GetComponent<RectTransform> ().sizeDelta.x, TipParent.GetComponent<RectTransform> ().sizeDelta.y + 30);
			AllTips.Add (tip);
			if (!TipMenu.activeSelf)
				gameObject.GetComponent<Image> ().color = Color.yellow;
		}
	}

	public bool IsTipFirst(string tip)
	{
		foreach (string t in AllTips)
			if (t == tip)
				return false;
		return true;
	}
		
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			TipMenu.SetActive (true);
			gameObject.GetComponent<Image> ().color = Color.white;
		}
	}
	public void CloseTipMenu(){
		TipMenu.SetActive (false);
	}

	private static TipManager instance;
	public static TipManager Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<TipManager> ();
			}
			return instance;
		}
	}
}
