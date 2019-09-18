using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightImage : MonoBehaviour {

    public void LightOn()
    {
        GetComponent<Image>().color = Color.yellow;
    }

    public void LightOff()
    {
		GetComponent<Image>().color = Color.white;
    }

}
