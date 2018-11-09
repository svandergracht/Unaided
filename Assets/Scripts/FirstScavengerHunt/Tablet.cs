using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {
    bool isSelected = false;
    GameObject playerGO;
    Player player;
    GameObject scavengerController;
    ScavengerHuntController shc;
    //public GameObject tablet;

    // Use this for initialization
    void Start () {
        playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
        scavengerController = GameObject.Find("ScavengerController");
        shc = scavengerController.GetComponent<ScavengerHuntController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isSelected && this.transform.parent.CompareTag("Holder")) {
            Debug.Log("I told you not to touch that! At least you have the password now though...");
            player.ChangeComplianceScore(-10);
            shc.AddCluesFound(4);
            isSelected = true;
        }
	}
}
