using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTableScript : MonoBehaviour {

    public GameObject tilePrefab;
    private GameObject grid;
    private Vector3 gridPos;
    private float gridSize;

    private GameObject[,] tiles;

	// Use this for initialization
	void Start () {
        //set up values
        grid = GameObject.Find("GridTable");
        gridPos = grid.transform.position;
        gridSize = grid.GetComponent<Collider>().bounds.size.x;

        // Configure
        ConfigureGrid(5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Set up the tiles
    private void ConfigureGrid(int rows, int cols) {

        Debug.Log("CONFIG");
        //Set up initial values
        //TODO: fix these magic numbers
        float startPosX = gridPos.x - (gridSize / 2) + .5f;
        float startPosY = gridPos.y + 0.25f;   
        float startPosZ = gridPos.z - (gridSize / 2) + .5f;
        Vector3 startPos = new Vector3(startPosX, startPosY, startPosZ);
        float offset = 1f;

        tiles = new GameObject[rows, cols];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                GameObject tile = Instantiate(tilePrefab) as GameObject;

                tile.transform.SetParent(grid.transform);

                float posX = (offset * i) + startPos.x;
                float posZ = (offset * j) + startPos.z;
                tile.transform.position = new Vector3(posX, startPos.y, posZ);

                //put it in the array
                tiles[i, j] = tile;
            }
        }
    }

    //Gets the array of tiles
    public GameObject[,] GetTileArray() {
        return tiles;
    }
}
