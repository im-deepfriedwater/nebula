using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;

public class Linkable : MonoBehaviour
    , IColliderEventHoverEnterHandler
    , IColliderEventHoverExitHandler
{
    public static bool colliding = false;
    public static Vector3 position;

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        colliding = true;
        position = this.transform.position;
        Debug.Log("*hacker voice* im in");
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        colliding = false;
        Debug.Log("we out");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
