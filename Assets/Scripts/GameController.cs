using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject robotPrefab;
    private Text topRightGT;
    private int score;

    private Text topLeftUIGT;
    private int health = 200;
    private const int healthHit = 25;
    private bool playerHitBefore = false;
    private int fixedTimeCount = 0;

    private int numEnemies = 16; 

    [SerializeField] private Popup popup;
    [SerializeField] private Text popupText;
    [SerializeField] private Button popupButton;
    [SerializeField] private Image damageIndicator;

    //grid table script 
    [SerializeField] private GridTableScript gridTableScript;

    private BattleShipGameController battleShipGameController;

    // Use this for initialization
    void Start () {
        popup.Close();

        //get reference to score objects
        //GameObject scoreGO = GameObject.Find("Score");
        //scoreGT = scoreGO.GetComponent<Text>();

        //get reference to health objects
        //GameObject healthGO = GameObject.Find("Health");
        //healthGT = healthGO.GetComponent<Text>();
        //healthGT.text = "Health: " + health;
        //damageIndicator.enabled = false;

        //create the battleship game controller
        //battleShipGameController = new BattleShipGameController();
        battleShipGameController = this.gameObject.AddComponent<BattleShipGameController>();


    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        fixedTimeCount++;
        if (fixedTimeCount >= 25) {
            playerHitBefore = false;
            fixedTimeCount = 0;
            damageIndicator.enabled = false;

        }
    }

    public void AdjustScore(int newScore) {
        score += newScore;
        //scoreGT.text = "Score: " + score;

        if (score == numEnemies)
        {
            popup.Open();
        }
    }

    //if the player has been hit within the last second, this method makes the player invincible for a short period of time.
    public void AdjustHealth() {
        if (playerHitBefore == false) {
            health = health - healthHit;
            //healthGT.text = "Health: " + health;
            damageIndicator.enabled = true;
            playerHitBefore = true;
        }

        if (health <= 0) {
            popupText.text = "You lose!" + "\n" + "Play again?";
            popup.Open();
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene("Scene", LoadSceneMode.Single);
    }

}
