﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("8")){
            SceneManager.LoadScene("CrewQuarters");
            SceneManager.UnloadScene("BattleShip");
        }
        else if(Input.GetKeyDown("6")){
            SceneManager.LoadScene("BattleShip");
            SceneManager.UnloadScene("CrewQuarters");
        }
	}

}
