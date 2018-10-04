using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour {

    public Vector3 PositionOffset;
    //public SteamVR_TrackedObject Controller;

    void OnTriggerEnter (Collider other)
    {
        //var device = SteamVR_Controller.Input((int)Controller.index);
        //device.TriggerHapticPulse(500, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        other.attachedRigidbody.position = new Vector3(20, 20, 20);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
