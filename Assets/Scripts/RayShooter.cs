﻿using System.Collections;
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

            //Enabling code below allows the player to shoot a laser
            //GameObject laser = Instantiate(laserPrefab) as GameObject;
            //laser.transform.rotation = this.transform.rotation;
            //laser.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);

        }
    }
}

