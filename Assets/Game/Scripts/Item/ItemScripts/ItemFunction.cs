using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemFunction : MonoBehaviour, IPointerClickHandler
{
	public Item MyItem;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
			if (InventoryScript.Instance.IsAnySlotEmpty)
            {
                //Debug.Log ("added");
				InventoryScript.Instance.AddItem(MyItem);
                Destroy(gameObject);
            }
        }
    }
}
