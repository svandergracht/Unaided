using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleShipUIController : MonoBehaviour {
    [SerializeField] private Text ShipHealthLabel;
    [SerializeField] private Text RoundNumberLabel;
    [SerializeField] private Text TimerLabel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShipHealth(int health) {
        ShipHealthLabel.text = "Ship Health: " + health;
    }

    public void SetRoundNumber(int round)
    {
        RoundNumberLabel.text = "Round: " + round;
    }

    public void SetTimerLabel(int time)
    {
        TimerLabel.text = "Time: " + time;
    }
}
