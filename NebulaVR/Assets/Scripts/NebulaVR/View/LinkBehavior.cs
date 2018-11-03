using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;

public class LinkBehavior : MonoBehaviour {
    Vector3 startPos;
    Vector3 endPos;

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

	void Update () {
        GameObject rightHand = GameObject.Find("RightHand");
        if (Linkable.colliding)
            //SEND BOOLEANS OF PRESSDOWN TO LINKABLE TO GET MOST UPDATED POSITIONS
        {
            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip))
            {
                startPos = Linkable.position;
                Debug.Log(Linkable.colliding);
            }

            if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip))
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
