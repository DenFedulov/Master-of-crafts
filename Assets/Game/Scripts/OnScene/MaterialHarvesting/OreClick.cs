using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OreClick : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null && CampfireScript.Instance != null && CampfireScript.Instance.Flaming) {
				if (MoveItem.Instance.TakenItem.Id == 7) {
					ContextValues.Instance.MaterialHarvest = 3;
					ContextValues.Instance.ContSlot = null;
					CraftMenuOpen.Instance.OpenCraftMenu ();
				}
			}
		}
	}
}
