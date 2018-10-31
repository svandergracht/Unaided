using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipGameController : MonoBehaviour {
    //references to battleship tiles, temporary
    [SerializeField] BattleShipTile tile0;
    [SerializeField] BattleShipTile tile1;
    [SerializeField] BattleShipTile tile2;
    [SerializeField] BattleShipTile tile3;
    [SerializeField] BattleShipTile tile4;

    private int currentRound = 1;
    //Includes the round number, and the number of asteroids per level 
    private Dictionary<int, int> RoundDictionary = new Dictionary<int, int>();

    //the battleship game board
    private List<BattleShipTile> gameBoard = new List<BattleShipTile>();

    //current instance of BattleShipRoundController
    private BattleShipRoundController battleShipRoundController;

    // Use this for initialization
    void Start () {
        //need to make this dynamic like the card game program
        gameBoard.Add(tile0);
        gameBoard.Add(tile1);
        gameBoard.Add(tile2);
        gameBoard.Add(tile3);
        gameBoard.Add(tile4);

        //add the levels
        RoundDictionary.Add(1, 6);
        RoundDictionary.Add(2, 12);
        RoundDictionary.Add(3, 18);

        //load the first round to start things off
        CreateRound();
    }
	
	// Update is called once per frame
	void Update () {
        //while (currentRound <= RoundDictionary.Count) {

        //}
	}

    private void CreateRound() {
        battleShipRoundController = new BattleShipRoundController();
        battleShipRoundController.StartGame(RoundDictionary[currentRound], (4 * currentRound), gameBoard);
    }

    public void LoadNextRound() {
        currentRound++;
    }
}
