using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipGameController : MonoBehaviour {

    private int currentRound = 1;
    //Includes the round number, and the number of asteroids per level 
    private Dictionary<int, int> roundDictionary = new Dictionary<int, int>();

    //the battleship game board
    private List<GameObject> gameBoard = new List<GameObject>();

    //current instance of BattleShipRoundController
    private BattleShipRoundController battleShipRoundController;

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
            //Debug.Log("Grid tiles go: " + gridTilesGO[i].name);

            //BattleShipTile tile = (BattleShipTile)gridTilesGO[i].GetComponent(typeof(BattleShipTile));
            gameBoard.Add(gridTilesGO[i]);
        }

        //add the levels
        roundDictionary.Add(1, 6);
        roundDictionary.Add(2, 12);
        roundDictionary.Add(3, 18);

        //load the first round to start things off
        CreateRound();
    }
	
	// Update is called once per frame
	void Update () {
        //while (currentRound <= RoundDictionary.Count) {

        //}
	}

    private void CreateRound() {
        //battleShipRoundController = new BattleShipRoundController();
        battleShipRoundController = this.gameObject.AddComponent<BattleShipRoundController>();

        battleShipRoundController.StartGame(roundDictionary[currentRound], (4 * currentRound), gameBoard);
    }

    public void LoadNextRound() {
        currentRound++;
    }
    
}
