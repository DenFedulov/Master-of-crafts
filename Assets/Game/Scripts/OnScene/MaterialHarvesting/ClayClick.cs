using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClayClick : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null) {
				if (MoveItem.Instance.TakenItem.Id == 12 && PitScript.Instance != null && PitScript.Instance.WaterIn >= 50) {
					ContextValues.Instance.MaterialHarvest = 2;
					ContextValues.Instance.ContSlot = null;
					CraftMenuOpen.Instance.OpenCraftMenu ();
				}
			}
		}
	}
}
