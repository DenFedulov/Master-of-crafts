using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TipClose : MonoBehaviour, IPointerClickHandler {
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			TipManager.Instance.CloseTipMenu ();
		}
	}
}
