using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public void TurnOn()
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void TurnOff()
    {
        gameObject.transform.position = new Vector3(-400f,-273.23f,0f);
    }

    void Start()
    {
        
    }

    private static Activator instance;
    public static Activator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Activator>();
            }
            return instance;
        }
    }
}
