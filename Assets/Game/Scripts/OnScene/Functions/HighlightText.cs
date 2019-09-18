using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightText : MonoBehaviour {

    public void LightOn()
    {
        GetComponent<Text>().color = Color.yellow;
    }

    public void LightOff()
    {
        GetComponent<Text>().color = Color.white;
    }

}
