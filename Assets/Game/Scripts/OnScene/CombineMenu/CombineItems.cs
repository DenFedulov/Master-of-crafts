using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombineItems : MonoBehaviour, IPointerClickHandler
{
	public GameObject CombMenu;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			CombMenu.SetActive (true);
			CombineMenu.Instance.AddCombineSlots ();
		}
	}
}
