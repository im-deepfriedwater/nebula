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

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Debug.Log("New Line Created!");
        Debug.Log(start);
        Debug.Log(end);
    }
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
                Debug.Log(Linkable.colliding);
            }

            if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip) || ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Grip))
            {
                if (endPos != startPos)
                {
                    endPos = Linkable.position;
                    DrawLine(startPos, endPos, Color.yellow);
                }
            }
        }
        
    }
}
