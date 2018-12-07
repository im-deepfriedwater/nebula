using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class ViewDeleteBehavior : MonoBehaviour
{
    [SerializeField]
    HandRole selectedHand;
    [SerializeField]
    ViewModelLayer vml;

    GameObject toDelete;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CheckOnEnter()
    {
        while (true)
        {
            if(toDelete != null && ViveInput.GetPressUp(selectedHand, ControllerButton.Grip))
            {
                // toDelete.getComponent
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        toDelete = c.gameObject;
    }

    void OnTriggerExit(Collider c)
    {
        toDelete = null;
    }
}
