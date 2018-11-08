using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{

    private Camera camera;
    public GameObject laserPrefab;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();
    }

    //try using transform shooting
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click");

            //This is tentative code to detect if a tile is clicked
            Vector3 origin = new Vector3(camera.pixelWidth / 2,
                                 camera.pixelHeight / 2,
                                 0);
            Ray ray = camera.ScreenPointToRay(origin);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Tile")) {
                    Debug.Log("You hit a tile!");
                    BattleShipTile tile = (BattleShipTile)(hit.transform.gameObject.GetComponent(typeof(BattleShipTile)));
                    tile.ChangeState();
                }
            }

        }
    }
}

