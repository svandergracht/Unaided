using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipGameController : MonoBehaviour {

    private int shipHealth = 100;

    private int currentRound = 1;
    //Includes the round number, and the number of asteroids per level 
    private Dictionary<int, int> roundDictionary = new Dictionary<int, int>();

    private int timeForRound = 8;

    //the battleship game board
    private List<GameObject> gameBoard = new List<GameObject>();

    //current instance of BattleShipRoundController
    private BattleShipRoundController battleShipRoundController;

    private BattleShipUIController UIController;

    private bool gameStarted = false;

    // Use this for initialization
    void Start () {
        //get reference to UIController
        GameObject UIControllerGO = GameObject.FindWithTag("UIController");
        UIController = (BattleShipUIController)(UIControllerGO.GetComponent(typeof(BattleShipUIController)));

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
        roundDictionary.Add(3, 14);
        roundDictionary.Add(4, 14);

        //load the first round to start things off
        CreateRound(roundDictionary[currentRound], true, timeForRound, gameBoard, this, UIController);
        gameStarted = true;
        //update UI
        UIController.SetRoundNumber(currentRound);
        UIController.SetShipHealth(shipHealth);
    }

    // Update is called once per frame
    void Update () {
        if (gameStarted && currentRound <= roundDictionary.Count) {
            if (battleShipRoundController.GetGameInPlay() == false) {
                //the current round has ended and there are more to go. Start the next round
                Debug.Log("Current round: " + currentRound);
                //calculate damage from previous round
                battleShipRoundController.CalculateDamage(gameBoard);
                CreateRound(roundDictionary[currentRound], true, timeForRound, gameBoard, this, UIController);
                currentRound = currentRound + 1;
                //update UI
                UIController.SetRoundNumber(currentRound);
                UIController.SetShipHealth(shipHealth);
            }
        } else {
            GameOver();
        }
	}

    private void GameOver() {
        gameStarted = false;
        Debug.Log("Battleship game over");
        battleShipRoundController.SetBoardNeutralState(gameBoard);
        Destroy(battleShipRoundController);
        Destroy(this);
    }

    private void CreateRound(int numAsteroids, bool displayAllAtOnce, int aTimeForRound, List<GameObject> gameBoard, BattleShipGameController gameController, BattleShipUIController aUIController) {
        //battleShipRoundController = new BattleShipRoundController();
        battleShipRoundController = this.gameObject.AddComponent<BattleShipRoundController>();

        battleShipRoundController.StartGame(numAsteroids, displayAllAtOnce, aTimeForRound, gameBoard, this, aUIController);
        gameStarted = true;
    }

    public void LoadNextRound() {
        currentRound++;
    }

    /// <summary>
    /// Decreases the ship health. Amount is subtracted from the ship health. 
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void DecreaseShipHealth(int amount) {
        shipHealth = shipHealth - amount;
        Debug.Log("Ship health: " + shipHealth);

        //if the health goes to 0 or below, game over
        if (shipHealth <= 0) {
            gameStarted = false;
            Debug.Log("Battleship game over");
            battleShipRoundController.SetBoardNeutralState(gameBoard);
            Destroy(battleShipRoundController);
            Destroy(this);
        }
    }
}
