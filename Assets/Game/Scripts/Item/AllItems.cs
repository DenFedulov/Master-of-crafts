using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllItems : MonoBehaviour{

	private static AllItems instance;
	public static AllItems Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<AllItems> ();
			}
			return instance;
		}
	}

	public Item[] ItemsArray;

	void Awake()
	{
		Item[] tr = Resources.LoadAll<Item> ("Items");
		ItemsArray = new Item[tr.Length+1];
		for (int i = 0; i < tr.Length; i++)
			ItemsArray [tr [i].Id] = tr[i];
	}


    public void Drop(GameObject pr)
    {
		if (pr.GetComponent<PitScript> () != null && SaveLoad.Instance.IsPitOn == false || pr.GetComponent<CampfireScript> () != null && SaveLoad.Instance.IsCampfireOn == false || pr.GetComponent<ItemFunction>() != null || pr.GetComponent<Ladder>() != null) {
			GameObject tpr = Instantiate (pr);
			tpr.transform.SetParent (Outside.Instance.gameObject.transform);
			tpr.transform.localScale = new Vector3 (1f, 1f, 1f);
			tpr.transform.localPosition = new Vector3 (Random.Range (-142, 220), Random.Range (-110, -27), 0);
			tpr.transform.SetSiblingIndex (1);
		}
    }

	public void RanDrop()
	{
		int r;
		do
		{
			r = Random.Range(1, 3);
		} while (r == 3);
		if(Random.Range(0,101) <= 20)
			Drop(ItemsArray[r].ItemPref);
	}
}
