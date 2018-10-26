using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameController controller;


	// Use this for initialization
	void Start () {
        GameObject controllerGO = GameObject.Find("GameController");
        // controller code below taken from https://answers.unity.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
        controller = (GameController)controllerGO.GetComponent(typeof(GameController));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }
}
