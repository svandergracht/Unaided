using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipTileController : MonoBehaviour {

    //references to battleship tiles
    [SerializeField] BattleShipTile tile0;
    [SerializeField] BattleShipTile tile1;
    [SerializeField] BattleShipTile tile2;
    [SerializeField] BattleShipTile tile3;
    [SerializeField] BattleShipTile tile4;

    private List<BattleShipTile> tileArray = new List<BattleShipTile>();

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
        StartGame(3, 7);
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
        tileArray.Add(tile0);
        tileArray.Add(tile1);
        tileArray.Add(tile2);
        tileArray.Add(tile3);
        tileArray.Add(tile4);

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
    /// Given an input list of BattleShipTiles, pick a specified number of tiles randomly.
    /// </summary>
    /// <returns>The picked tile indexes.</returns>
    /// <param name="numTilesToPick">Number tiles, must be less than the input array length.</param>
    /// <param name="inputList">Input array. It is passed by value so you can use it internally
    /// to check valid choices</param>
    /// valid choices idea from: https://answers.unity.com/questions/452983/how-to-exclude-int-values-from-randomrange.html
    private int[] PickTiles(int numTilesToPick, List<BattleShipTile> inputList) {
        //indexes of picked tiles to return
        int[] pickedTilePositions = new int[numTilesToPick];

        //make list of valid indexed of input list
        List<int> validChoices = new List<int>();
        for (int i = 0; i < inputList.Count; i++) {
            validChoices.Add(i);
        }

        //pick the indexes to return
        int numPicked = 0;
        while (numPicked < numTilesToPick) {
            int randomNum = Random.Range(0, validChoices.Capacity - 1);
            pickedTilePositions[numPicked] = validChoices[randomNum];
            validChoices.RemoveAt(randomNum);
            numPicked++;
        }

        return pickedTilePositions;
    }
}
