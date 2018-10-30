﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipTileController : MonoBehaviour {

    //references to battleship tiles
    [SerializeField] BattleShipTile tile0;
    [SerializeField] BattleShipTile tile1;
    [SerializeField] BattleShipTile tile2;
    [SerializeField] BattleShipTile tile3;
    [SerializeField] BattleShipTile tile4;
    
    private BattleShipTile[] tileArray = new BattleShipTile[5];

    //boolean indicating wheter the mini-game has started or not
    //private bool gameStarted;

    //keep track of where you are between 0 and the max time for round
    private float roundTimer;
    //how long a round can last
    private float maxTimeForRound;
    private float timeBetweenRounds;
    private int currentRound = 1;
    private int numRounds = 3;

    //array containing indexes of tiles to pick out of tile array
    private int[] pickedTiles;

    //Want to make an algorithm that randomly picks a number of tiles to set to incoming.

    // Use this for initialization
    void Start () {
        //temporarily calling StartGame from in here. The overarching game controller should call start game with parameters
        StartGame(2, 7);
    }

    private void Awake()
    {

    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <param name="numAsteroids">Number asteroids, must be less than the grid size.</param>
    /// <param name="timeForRound">Time for round.</param>
    public void StartGame(int numAsteroids, int timeForRound) {
        maxTimeForRound = timeForRound;

        //need to make this dynamic like the card game program
        tileArray[0] = tile0;
        tileArray[1] = tile1;
        tileArray[2] = tile2;
        tileArray[3] = tile3;
        tileArray[4] = tile4;

        //gameStarted = true;
        pickedTiles = PickTiles(numAsteroids, tileArray);
        roundTimer = 0;

        //print out picked tiles
        for (int i = 0; i < pickedTiles.Length; i++) {
            Debug.Log("Picked tiles: " + pickedTiles[i]);
        }

        //change the states of the picked tiles
        int counter = 0;
        while (counter < pickedTiles.Length) {
            tileArray[pickedTiles[counter]].SetStateIncoming();
            counter++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Given an input array of BattleShipTiles, pick a specified number of tiles randomly.
    /// </summary>
    /// <returns>The picked tile indexes.</returns>
    /// <param name="numTilesToPick">Number tiles, must be less than the input array length.</param>
    /// <param name="inputArray">Input array.</param>
    /// valid choices idea from: https://answers.unity.com/questions/452983/how-to-exclude-int-values-from-randomrange.html
    private int[] PickTiles(int numTilesToPick, BattleShipTile[] inputArray) {
        //indexes of picked tiles to return
        int[] pickedTilePositions = new int[numTilesToPick];

        //possible choices
        List<int> validChoices = new List<int>(new int[inputArray.Length]);

        //pick the indexes to return
        int numPicked = 0;
        while (numPicked < numTilesToPick) {
            int randomNum = Random.Range(0, validChoices.Count - 1);
            pickedTilePositions[numPicked] = randomNum;
            validChoices.RemoveAt(randomNum);
            numPicked++;
        }

        return pickedTilePositions;
    }
}
