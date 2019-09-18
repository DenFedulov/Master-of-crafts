using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour, IPointerClickHandler
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
            ContextValues.Instance.ContSlot.RemoveItem();
        }
    }
}
