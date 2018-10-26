using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private GameController controller;
    public GameObject robot;
    public GameObject laserPrefab;
    private Laser laserScript;

    // Use this for initialization
    void Start () {

        robot = this.gameObject;
        GameObject controllerGO = GameObject.Find("GameController");
        // controller code below taken from https://answers.unity.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
        controller = (GameController)controllerGO.GetComponent(typeof(GameController));
    }

    // Update is called once per frame
    void Update () {
        //have the enemy look for players
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit, 25f)) {
            GameObject target = hit.transform.gameObject;
            if (target.tag == "Player") {
                Debug.Log("Player found!");
                ShootTarget(target);
            }
        }
    }

    //private void ShootTarget(GameObject target) {
      //  rayShooter.Shoot(target.transform.position, true);
    //}

   private void ShootTarget(GameObject target) {
        //yield return new WaitForSeconds(0.5f);
        Debug.Log("shooting");
        GameObject laser = Instantiate(laserPrefab) as GameObject;
        laserScript = (Laser)laser.GetComponent(typeof(Laser));
        laserScript.SetLaserSpeed(0.7f);

        laser.transform.rotation = this.transform.rotation;
        laser.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;
        if (collidedWith.tag == "Laser")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            //update score through controller method
            controller.AdjustScore(1);
        }
    }
}
