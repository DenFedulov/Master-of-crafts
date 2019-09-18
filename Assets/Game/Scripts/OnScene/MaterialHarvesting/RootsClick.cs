using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RootsClick : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null) {
				if (MoveItem.Instance.TakenItem.Id == 3 || MoveItem.Instance.TakenItem.Id == 7 || MoveItem.Instance.TakenItem.Id == 21) {
					ContextValues.Instance.MaterialHarvest = 1;
					ContextValues.Instance.ContSlot = null;
					CraftMenuOpen.Instance.OpenCraftMenu ();
				}
			}
		}
	}
}
