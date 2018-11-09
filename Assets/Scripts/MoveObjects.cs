using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {

    // Some contributions to this code were gotten from comments in a thread
    //forum linked here: https://forum.unity.com/threads/how-to-pick-up-and-move-objects-tutorial.496090/

    public GameObject item;
    public GameObject tempParent;
    public Transform person;

    //At the start of the game makes sure that any objects this script is
    //to have their gravity set to true
    void Start () {

        item.GetComponent<Rigidbody>().useGravity = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //When the mouse button is pressed down while hovering over the moveable
    //object the object's gravity is set to false and the object becomes
    //kinematic. After doing this the object's position is altered to be a set
    //distance away from the perspective of the player, the object becomes
    //a child of the player camera and moves along with the view of the player.
    private void OnMouseDown()
    {

        //this 
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = person.transform.position;
        item.transform.rotation = person.transform.rotation;
        item.transform.parent = tempParent.transform;

    }

    //After the mouse button is released the object is no longer kinematic, and
    //gravity is able to act on the object once again, causing the object to
    //fall back to the ground wherever the player has released it.
    private void OnMouseUp()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = person.transform.position;

    }
}
