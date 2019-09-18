using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Target : MonoBehaviour, IPointerClickHandler
{

    public int TargetId = 0;

    public int HitPoints = 3;

    public Sprite trg2, trg3;

	void Start () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && HitPoints > 0)
        {
            HitPoints--;
            if (HitPoints == 2)
            {
                GetComponent<Image>().sprite = trg2;
            }
            else if (HitPoints == 1)
            {
                GetComponent<Image>().sprite = trg3;
            }
            else
            {
                GetComponent<Image>().sprite = null;
                var t = GetComponent<Image>().color;
                t.a = 0f;
                GetComponent<Image>().color = t;
            }
            //Debug.Log("Target's ID = " + TargetId);
        }
    }

    private static Target instance;
    public static Target Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Target>();
            }
            return instance;
        }
    }
}
