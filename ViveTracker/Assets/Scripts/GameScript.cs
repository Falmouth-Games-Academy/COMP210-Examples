using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    public GameObject prefab;

    // Use this for initialization
    void Start () {
        // Calls TestCondition after 0 seconds 
        // and repeats every 5 seconds.
        InvokeRepeating("SpawnDuck", 0, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnDuck() {
        //Debug.Log("Spawning Duck!", gameObject);
        
        Vector3 pos = new Vector3(20f, 0.5f, Random.Range(10.0f, 20.0f));
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
