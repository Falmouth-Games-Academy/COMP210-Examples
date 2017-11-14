using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Pointers;



public class mapTUIO : MonoBehaviour
{

    public int markerID = 1;
    public GameObject actor;

    // Use this for initialization
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersAdded += pointersAddedHandler;
            TouchManager.Instance.PointersUpdated += pointersUpdateHandler;
            TouchManager.Instance.PointersRemoved += pointersRemovedHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersAdded -= pointersAddedHandler;
            TouchManager.Instance.PointersUpdated -= pointersUpdateHandler;
            TouchManager.Instance.PointersRemoved -= pointersRemovedHandler;
        }
    }

    private void pointersAddedHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            // Cast pointer to ObjectPointer
            ObjectPointer op = pointer as ObjectPointer;

            // if cast worked...
            if (op != null)
            {
                // check it is the right marker for this object
                if (markerID == op.ObjectId)
                {
                    // hide the GameObject
                    // show the object
                    actor.SetActive(true);
                    Debug.Log("added");
                }
            }
        }
    }

    private void pointersUpdateHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            // Cast pointer to ObjectPointer
            ObjectPointer op = pointer as ObjectPointer;

            // if cast worked...
            if (op != null)
            {
                // check it is the right marker for this object
                if (markerID == op.ObjectId)
                {
                    // Update the game objects position relative to the camera. 
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(op.Position.x, op.Position.y, 10));
                    transform.rotation = Quaternion.Euler(0, 0, op.Angle * -Mathf.Rad2Deg);

                    Debug.Log(op.Angle);

                    
                }
            }
        }
    }

    private void pointersRemovedHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            // Cast pointer to ObjectPointer
            ObjectPointer op = pointer as ObjectPointer;

            // if cast worked...
            if (op != null)
            {
                // check it is the right marker for this object
                if (markerID == op.ObjectId)
                {
                    // hide the GameObject
                    actor.SetActive(false);

                    Debug.Log("removed");
                }
            }
        }
    }
}

    


