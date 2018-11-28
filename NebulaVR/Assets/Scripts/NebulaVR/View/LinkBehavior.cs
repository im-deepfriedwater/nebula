using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;

public class LinkBehavior : MonoBehaviour {
    Vector3 startPos;
    Vector3 endPos;
    GameObject rightHand;
    GameObject leftHand;

    [SerializeField]
    GameObject prefabDrawLink;
    public static List<Linkable> potentialLinkTargets = new List<Linkable>();

    void Start ()
    {
        rightHand = GameObject.Find("RightHand");
        leftHand = GameObject.Find("LeftHand");
        
    }
	void Update () {
        
        if (Linkable.colliding)
        {
            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip) || ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Grip))
            {
                startPos = Linkable.position;
                Debug.Log("Begin Linking");
            }

            if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip) || ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Grip))
            {
                if (endPos != startPos)
                {
                    endPos = Linkable.position;
                    Linkable.colliding = false;
                    CreateLine();
                }
            }
        } 
    }

    void CreateLine()
    {
        var drawLinkBehaviour = Instantiate(prefabDrawLink).GetComponent<DrawLinkBehaviour>();
        drawLinkBehaviour.Initialize(startPos, endPos);
    }
}
