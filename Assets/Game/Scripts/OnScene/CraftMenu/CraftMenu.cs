using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour {

    public GameObject targetPref;

    public List<Target> targets;

	void Start () {
        
	}

    public void AddTargets()
    {
        targets = new List<Target>();
        for (int i = 0; i < 9; i++)
        {
            Target targ = Instantiate(targetPref, transform).GetComponent<Target>();
            targ.TargetId = i + 1;
            targets.Add(targ);
        }
    }

	public bool AreTargetsFull
	{
		get {
			foreach (Target trg in targets)
				if (trg.HitPoints < 3)
					return false;
			return true;
		}
	}

    private static CraftMenu instance;
    public static CraftMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CraftMenu>();
            }
            return instance;
        }
    }
}
