using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ladder : MonoBehaviour, IPointerClickHandler 
{
	public Item MyItem;

	public GameObject im,txt;

	void Start()
	{
		gameObject.transform.localPosition = new Vector3 (-289, 49);
		gameObject.transform.SetAsLastSibling ();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			im.SetActive (true);
			txt.SetActive (true);
		}
	}
}

