using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObCanvas : MonoBehaviour {

	public GameObject Console;

	void Update(){
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			Console.SetActive (!Console.activeSelf);
			Console.GetComponent<InputField> ().Select ();
			Console.GetComponent<InputField> ().text = "";
		}
	}

    private static ObCanvas instance;
    public static ObCanvas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObCanvas>();
            }
            return instance;
        }
    }
}
