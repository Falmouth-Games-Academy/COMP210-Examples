using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * (-Time.deltaTime*10));

        var pos = transform.position;

        if (pos.x < -20f)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }

        
    }
}
