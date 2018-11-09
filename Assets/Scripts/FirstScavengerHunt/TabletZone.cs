using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletZone : Item {

    bool isFound = false;
    bool isSelected = false;
    GameObject playerGO;
    Player player;
    GameObject scavengerController;
    ScavengerHuntController shc;

    // Use this for initialization
    void Start()
    {
        playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
        scavengerController = GameObject.Find("ScavengerController");
        shc = scavengerController.GetComponent<ScavengerHuntController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void InteractWith()
    {
        if (!isFound) {
            //TODO: change to UI display
            Debug.Log("You are prohibited from accessing the personal tablet of the Mechanic. Do not touch the tablet.");
            isFound = true;
        }
    }
}
