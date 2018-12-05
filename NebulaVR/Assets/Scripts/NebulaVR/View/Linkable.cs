using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Vive;

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
        LinkBehavior.potentialLinkTargets.Add(this);
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        Debug.Log("grank baybee");
        colliding = false;
        position = this.transform.position;
    }
}
