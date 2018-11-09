using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass that represents an interactible item
public class Item : MonoBehaviour {
    //bool isFound = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void InteractWith() {
        //Do Something
        //if (!isFound)
        //{
        //    isFound = true;   //first time, set it to found
        //}
    }

    public virtual void PlayAudio() {
        //Play audio clip
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            InteractWith();
        }
    }
}
