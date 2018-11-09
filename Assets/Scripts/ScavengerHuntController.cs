using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RIGHT NOW: design is for finding a # of clues, not finding a specific clue
public class ScavengerHuntController : MonoBehaviour {
    private int numCluesFound;


	// Use this for initialization
	void Start () {
        numCluesFound = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Adds to the number of clues found
    public void AddCluesFound(int numOfClues) {
        numCluesFound+= numOfClues;
        Debug.Log("Clues found: " + numCluesFound);
    }

    // Ends the mini game
    public void EndHunt(bool followedDirections) {
        //TODO: how do we unlock/load the next scene?
        Debug.Log("YOU UNLOCKED THE DOOR");
        if (followedDirections) {
            RunGoodDialog();
        } else {
            RunBadDialog();
        }
    }

    // Checks if the game is over
    public bool IsHuntOver(int cluesRequired) {
        if (numCluesFound == cluesRequired) {
            EndHunt(true);
            return true;
        } else if (numCluesFound > cluesRequired) {
            EndHunt(false);
            return true;
        }
        return false;
    }

    //TODO: These are temporary for the 2nd Playable
    public void RunGoodDialog() {
        Debug.Log("You follow instructions well, human.");
    }

    public void RunBadDialog() {
        Debug.Log("You were not very compliant. I told you not to go through your crewmate's personal belongings.");
    }
}
