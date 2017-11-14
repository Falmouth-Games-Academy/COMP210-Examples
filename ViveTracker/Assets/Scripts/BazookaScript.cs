using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaScript : MonoBehaviour {

    public GameObject rocketPrefab;
    public Transform rocketSpawn;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space")) {
            fire();
        }
    }

    public void fire()
    {
        print("Rocket Fired");

        // Create the Bullet from the Bullet Prefab
        var rocket = (GameObject)Instantiate(
            rocketPrefab,
            rocketSpawn.position,
            rocketSpawn.rotation);

        // Add velocity to the bullet
        rocket.GetComponent<Rigidbody>().velocity = rocket.transform.right * 20;

        // Destroy the bullet after 2 seconds
        Destroy(rocket, 4.0f);
    }
}
