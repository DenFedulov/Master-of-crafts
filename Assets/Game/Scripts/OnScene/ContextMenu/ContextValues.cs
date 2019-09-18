using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextValues : MonoBehaviour {

    public SlotScript ContSlot;

	public int ContId;

	public int MaterialHarvest = 0;

	void Update(){
		if (ContSlot != null && !ContSlot.IsEmpty)
			ContId = ContSlot.Items.Peek ().Id;
	}

    private static ContextValues instance;
    public static ContextValues Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ContextValues>();
            }
            return instance;
        }
    }
}
