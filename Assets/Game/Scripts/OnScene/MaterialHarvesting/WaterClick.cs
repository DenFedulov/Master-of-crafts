using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterClick : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null && CampfireScript.Instance != null && CampfireScript.Instance.Flaming) {
				if (MoveItem.Instance.TakenItem.Id == 15) {
					MoveItem.Instance.TakenItem = AllItems.Instance.ItemsArray [16];
					MoveItem.Instance.IconSet (AllItems.Instance.ItemsArray [16].icon);
				}
			}
		}
	}
}
