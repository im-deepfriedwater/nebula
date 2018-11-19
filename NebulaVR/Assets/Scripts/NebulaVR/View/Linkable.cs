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
        this.colliding = true;
        position = this.transform.position;
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        this.colliding = false;
    }
}
