using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
