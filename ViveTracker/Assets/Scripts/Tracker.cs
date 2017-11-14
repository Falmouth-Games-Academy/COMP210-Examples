using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;

    public BazookaScript bazooka;

    [SerializeField]
    private bool grip;

    [SerializeField]
    private bool trigger;

    [SerializeField]
    private bool trackpad;

    [SerializeField]
    private bool menu;


    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();

	}
	
	// Update is called once per frame
	void Update () {

        var device = SteamVR_Controller.Input((int)trackedObject.index);

        grip = device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip);
        menu = device.GetPress(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu);
        trigger = device.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        trackpad = device.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

        if (grip) bazooka.fire();
        
    }
}
