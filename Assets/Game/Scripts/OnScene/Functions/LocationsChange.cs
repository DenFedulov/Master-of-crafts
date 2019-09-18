using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationsChange : MonoBehaviour, IPointerClickHandler  {

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			Outside.Instance.gameObject.transform.SetSiblingIndex (Cave.Instance.gameObject.transform.GetSiblingIndex());
		}
	}
}
