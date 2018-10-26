using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject laser;
    //deafult laser speed of 2f
    private float laserSpeed = 2f;
    private int moveCount = 0;
    private const int maxMoveCount = 250;

    // Use this for initialization
    void Start()
    {
        laser = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        laser.transform.position = this.transform.TransformPoint(Vector3.forward * laserSpeed);
        moveCount++;
        if (moveCount > maxMoveCount) {
            Destroy(laser);
        }   
    }

    public void SetLaserSpeed(float aSpeed) {
        laserSpeed = aSpeed;
    }

}