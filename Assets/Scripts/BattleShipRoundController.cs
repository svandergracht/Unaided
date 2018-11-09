using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipRoundController : MonoBehaviour {

    //private List<BattleShipTile> tileArray = new List<BattleShipTile>();
    //reference to gameBoard
    private List<GameObject> gameBoard = new List<GameObject>();

    //boolean indicating wheter the mini-game is in play or not
    private bool gameInPlay;

    private int asteroidDamage = 5;

    //keep track of where you are between 0 and the max time for round
    private float currentTime;

    //array containing indexes of tiles to pick out of tile array
    private int[] pickedTiles;

    //reference to BattleShipGameController
    BattleShipGameController gameController;

    private BattleShipUIController UIController;


    // Use this for initialization
    void Start () {

    }

    private void Awake()
    {

    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    /// <param name="numAsteroids">Number asteroids, must be less than the grid size.</param>
    /// <param name="timeForRound">Time for round.</param>
    public void StartGame(int numAsteroids, bool displayAllAtOnce, int timeForRound, List<GameObject> aGameBoard, BattleShipGameController aGameController, BattleShipUIController aUIController) {
        //set controller references
        gameController = aGameController;
        UIController = aUIController;

        gameBoard = aGameBoard;

        //reset the board states
        SetBoardNeutralState(aGameBoard);

        //tileArray = gameBoard;
        Debug.Log("Time for round: " + timeForRound);

        currentTime = timeForRound;

        //gameStarted = true;
        pickedTiles = PickTiles(numAsteroids, aGameBoard);

        //print out picked tiles
        for (int i = 0; i < pickedTiles.Length; i++) {
            //Debug.Log("Picked tiles: " + pickedTiles[i]);
        }

        for (int i = 0; i < pickedTiles.Length; i++)
        {
            //Debug.Log("chaning state on: " + gameBoard[pickedTiles[i]]);
        }

        //change the states of the picked tiles
        int counter = 0;
        while (counter < pickedTiles.Length) {
            //BattleShipTile tile = gameBoard[pickedTiles[counter]].GetComponent<BattleShipTile>();
            aGameBoard[pickedTiles[counter]].GetComponent<BattleShipTile>().SetStateIncoming();
            //tile.SetStateIncoming();
            //tileArray[pickedTiles[counter]].SetStateIncoming();
            counter++;
        }

        gameInPlay = true;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("game in play: " + gameInPlay);
        //Debug.Log("time: " + currentTime);
        if (gameInPlay && currentTime > 0) {
            currentTime = currentTime - Time.deltaTime;
            UIController.SetTimerLabel((int)currentTime);
            //Debug.Log("Time left: " + currentTime);
        
        } else {
            gameInPlay = false;
            Debug.Log("Round over");
        }
    }

    public void SetBoardNeutralState(List<GameObject> gameBoard) {
        for (int i = 0; i < gameBoard.Count; i++)
        {
            gameBoard[i].GetComponent<BattleShipTile>().SetNeutralState();
        }
    }

    /// <summary>
    /// Given an input list of BattleShipTiles, pick a specified number of tiles randomly.
    /// </summary>
    /// <returns>The picked tile indexes.</returns>
    /// <param name="numTilesToPick">Number tiles, must be less than the input array length.</param>
    /// <param name="inputList">Input array. It is passed by value so you can use it internally
    /// to check valid choices</param>
    /// valid choices idea from: https://answers.unity.com/questions/452983/how-to-exclude-int-values-from-randomrange.html
    private int[] PickTiles(int numTilesToPick, List<GameObject> inputList) {
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
            int randomNum = Random.Range(0, validChoices.Count - 1);
            pickedTilePositions[numPicked] = validChoices[randomNum];
            validChoices.RemoveAt(randomNum);
            numPicked++;
        }

        return pickedTilePositions;
    }

    public bool GetGameInPlay() {
        return gameInPlay;
    }

    public void CalculateDamage(List<GameObject> aGameBoard) {
        for (int i = 0; i < aGameBoard.Count; i++)
        {
            Debug.Log("In calculate damage");
            BattleShipTile tile = aGameBoard[i].GetComponent<BattleShipTile>();
            if (tile.IsIncomingState()) {
                Debug.Log("In calculate damage");
                gameController.DecreaseShipHealth(asteroidDamage);
            }
        }

    }
}
