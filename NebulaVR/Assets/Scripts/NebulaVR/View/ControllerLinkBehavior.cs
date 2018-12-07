using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class ControllerLinkBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject prefabDrawLink;
    [SerializeField]
    HandRole selectedHand;
    [SerializeField]
    ViewModelLayer vml;


    GameObject first;
    GameObject second;
	
	void Update()
    {
        if (ViveInput.GetPressUp(selectedHand, ControllerButton.Grip) && first != second)
        {
            if (first.tag == "Untagged" || second.tag == "Untagged")
            {
                Debug.Log("One of the parents is not accepting any more links.");
            }
            else
            {
                DrawLine();
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

    void DrawLine()
    {
        var drawLinkObject = vml.ConstructAndBindViewLink(first.transform.position, second.transform.position);
        drawLinkObject.GetComponent<DrawLinkBehaviour>().Initialize(first, second);
    }
}
