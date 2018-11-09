using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : Item {
    GameObject scGO;
    ScavengerHuntController shc;
    bool madeCheck = false;
    bool isFound = false;


	// Use this for initialization
	void Start () {
        scGO = GameObject.Find("ScavengerController");
        shc = scGO.GetComponent<ScavengerHuntController>();
        Debug.Log("Checkout the terminal and see if there are instructions for opening the door.");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void InteractWith()
    {
        if (!madeCheck) {
            bool gameOver = shc.IsHuntOver(3);
            if (gameOver) {
                madeCheck = true;
            }
        }
        if (!isFound && shc.IsHuntOver(3) == false) {
            Debug.Log("This is probably hooked up to the mechanic's account. Search his area on the far side of the room for clues.");
            isFound = true;
        }
    }
}
