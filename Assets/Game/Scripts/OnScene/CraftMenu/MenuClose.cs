using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuClose : MonoBehaviour, IPointerClickHandler
{
    public GameObject menu;

    public void Close()
    {
        foreach (Target trg in CraftMenu.Instance.targets)
        {
			Destroy(trg.gameObject);
        }
        menu.SetActive(false);
		ContextValues.Instance.MaterialHarvest = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Close();
        }
    }

    private static MenuClose instance;
    public static MenuClose Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuClose>();
            }
            return instance;
        }
    }
}
