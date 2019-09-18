using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PitScript : MonoBehaviour, IPointerClickHandler {

	public Item Me;

	public float WaterIn = 0;
	public Image Fill;

	void Start () {
		gameObject.transform.localPosition = new Vector3 (-210, -100);
		SaveLoad.Instance.IsPitOn = true;
		gameObject.transform.SetParent(Outside.Instance.gameObject.transform);
	}

	void Update () {
		Fill.fillAmount = (WaterIn / 100)* 0.85f;
		if (Rain.Instance.IsRaining)
			WaterIn += Time.deltaTime * 1.67f;
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null && MoveItem.Instance.TakenItem.Id == 16 && WaterIn < 100) {
				WaterIn += 50;
				MoveItem.Instance.TakenItem = AllItems.Instance.ItemsArray [15];
				MoveItem.Instance.IconSet (AllItems.Instance.ItemsArray [15].icon);
			} else
			if (MoveItem.Instance.TakenItem != null && MoveItem.Instance.TakenItem.Id == 15 && WaterIn >= 50) {
				WaterIn -= 50;
				MoveItem.Instance.TakenItem = AllItems.Instance.ItemsArray [16];
				MoveItem.Instance.IconSet (AllItems.Instance.ItemsArray [16].icon);
			}
		}
		if (eventData.button == PointerEventData.InputButton.Right) {
			
		}
	}

	void OnDestroy(){
		SaveLoad.Instance.IsPitOn = false;
	}
		
	private static PitScript instance;
	public static PitScript Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<PitScript> ();
			}
			return instance;
		}
	}
}
