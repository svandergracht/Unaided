using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTableScript : MonoBehaviour {

    public GameObject tilePrefab;
    private GameObject grid;
    private Vector3 gridPos;
    private float gridSize;
    private Vector3 startPos;
    private float offset = .33f;

    private List<GameObject> tiles;

	// Use this for initialization
	void Start () {
        //set up values
        grid = GameObject.Find("GridTable");
        gridPos = grid.transform.position;
        gridSize = grid.GetComponent<Collider>().bounds.size.x;

        Debug.Log("gridPos: " + gridPos);
        Debug.Log("gridSize: " + gridSize);
        float startPosX = gridPos.x - (gridSize / 2);
        float startPosY = gridPos.y - (gridSize / 2);
        float startPosZ = gridPos.z - 0.33f;    //HARDCODED BADLY
        startPos = new Vector3(startPosX, startPosY, startPosZ);

        // Configure
        ConfigureGrid(5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Set up the tiles
    public void ConfigureGrid(int rows, int cols) {
        //GameObject tile = Instantiate(tilePrefab) as GameObject;
        Vector3 currentPos = startPos;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                GameObject tile = Instantiate(tilePrefab) as GameObject;
                //tile.transform.SetParent(grid.transform);
                //Hardcode size

                float posX = (offset * i) + startPos.x;
                float posY = -(offset * j) + startPos.y;
                tile.transform.position = new Vector3(posX, posY, startPos.z);


                //put it in the list
                //stiles.Add(tile);
            }
        }
    }
}
