using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipGameController : MonoBehaviour {

    private int currentRound = 1;
    //Includes the round number, and the number of asteroids per level 
    private Dictionary<int, int> roundDictionary = new Dictionary<int, int>();

    private int timeForRound = 6;

    //the battleship game board
    private List<GameObject> gameBoard = new List<GameObject>();

    //current instance of BattleShipRoundController
    private BattleShipRoundController battleShipRoundController;

    private bool gameStarted = false;

    // Use this for initialization
    void Start () {
        //get reference to gridTableScript and setup gameboard
        GameObject gridTable = GameObject.FindWithTag("GridTable");
        GridTableScript gridTableScript = (GridTableScript)(gridTable.GetComponent(typeof(GridTableScript)));
        GameObject[] gridTilesGO = gridTableScript.GetTileArray();
        Debug.Log("Grid tiles count: " + gridTilesGO.Length);
        //setup gameboard
        for (int i = 0; i < gridTilesGO.Length; i++)
        {
            gameBoard.Add(gridTilesGO[i]);
        }

        //add the levels
        roundDictionary.Add(1, 6);
        roundDictionary.Add(2, 12);
        roundDictionary.Add(3, 18);

        //load the first round to start things off
        CreateRound(roundDictionary[currentRound], true, timeForRound, gameBoard);
        gameStarted = true;
        Debug.Log("round dict count: " + roundDictionary.Count);
    }

    // Update is called once per frame
    void Update () {
        if (gameStarted && currentRound <= roundDictionary.Count) {
            //the current round has ended and there are more to go. Start the next round
            if (battleShipRoundController.GetGameInPlay() == false) {
                Debug.Log("Current round: " + currentRound);
                CreateRound(roundDictionary[currentRound], true, timeForRound, gameBoard);
                currentRound = currentRound + 1;
            }
        } else {
            gameStarted = false;
            Debug.Log("Battleship game over");
            Destroy(battleShipRoundController);
            Destroy(this);
        }
	}

    private void CreateRound(int numAsteroids, bool displayAllAtOnce, int aTimeForRound, List<GameObject> gameBoard) {
        //battleShipRoundController = new BattleShipRoundController();
        battleShipRoundController = this.gameObject.AddComponent<BattleShipRoundController>();

        battleShipRoundController.StartGame(numAsteroids, displayAllAtOnce, aTimeForRound, gameBoard);
        gameStarted = true;
    }

    public void LoadNextRound() {
        currentRound++;
    }

}
