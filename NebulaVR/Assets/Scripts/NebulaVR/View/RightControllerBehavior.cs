using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class RightControllerBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject prefabDrawLink;

    GameObject first;
    GameObject second;
	
	void Update()
    {
        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip) && first != second)
        {
            if (first.tag == "Untagged" || second.tag == "Untagged")
            {
                Debug.Log("One of the parents is not accepting any more links.");
            }
            else
            {
                drawLine();
            }

        }
    }  

    void OnTriggerEnter(Collider c)
    {
        first = c.gameObject;
    }

    void OnTriggerExit(Collider c)
    {
        second = first;
    }

    void drawLine()
    {
        var drawLinkBehaviour = Instantiate(prefabDrawLink).GetComponent<DrawLinkBehaviour>();
        drawLinkBehaviour.Initialize(first, second);
    }
}
