using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : Item {

    bool isFound = false;
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
        if (!isFound)
        {
            player.ChangeComplianceScore(5);
            shc.AddCluesFound(1);
            isFound = true;   //first time, set it to found
        }
    }
}
