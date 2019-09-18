using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IPointerClickHandler
{

    public void LightOn()
    {
        GetComponent<Text>().color = Color.yellow;
    }

    public void LightOff()
    {
        GetComponent<Text>().color = Color.white;
    }

    void Update()
    {
        if (ContextValues.Instance.ContSlot != null)
        {
            if (ContextValues.Instance.ContSlot.IsEmpty)
            {
                GetComponent<Text>().color = Color.grey;
            }
            else
            {
                if (GetComponent<Text>().color != Color.yellow)
                    GetComponent<Text>().color = Color.white;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!ContextValues.Instance.ContSlot.IsEmpty)
            {
				switch (ContextValues.Instance.ContSlot.Items.Peek ().Id) {
				case 12:
					AllItems.Instance.Drop (AllItems.Instance.ItemsArray [10].ItemPref);
					break;
				default:
					AllItems.Instance.Drop (ContextValues.Instance.ContSlot.Items.Peek ().ItemPref);
					ContextValues.Instance.ContSlot.RemoveItem();
					break;
				}
            }
        }
	}
}
