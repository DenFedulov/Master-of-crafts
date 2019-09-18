using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightWithItem : MonoBehaviour {

    public void LightOn()
    {
        if (MoveItem.Instance.TakenItem != null)
        {
            GetComponent<Text>().color = Color.yellow;
        }
    }

    public void LightOff()
    {
        GetComponent<Text>().color = Color.white;
    }

    void Update()
    {
        if (ContextValues.Instance.ContSlot != null)
        {
            if (MoveItem.Instance.TakenItem == null || ContextValues.Instance.ContSlot.IsEmpty)
            {
                GetComponent<Text>().color = Color.grey;
            }
            else
            {
                if(GetComponent<Text>().color != Color.yellow)
                GetComponent<Text>().color = Color.white;
            }
        }
    }
}
