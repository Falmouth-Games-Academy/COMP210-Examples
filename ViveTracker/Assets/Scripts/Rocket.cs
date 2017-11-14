using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);

        var pos = transform.position;

        if (pos.y < -2f)
        {
            Debug.Log("Destroy Rocket");
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Duck"))
        {
            // Create the Bullet from the Bullet Prefab
            var newExplosion = (GameObject)Instantiate(
                explosion,
                transform.position,
                transform.rotation);

            Destroy(newExplosion, 4.0f);

            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
