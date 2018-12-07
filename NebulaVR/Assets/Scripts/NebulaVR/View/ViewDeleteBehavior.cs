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

    IEnumerator CheckOnEnter()
    {
        while (true)
        {
            if(toDelete != null && ViveInput.GetPressUp(selectedHand, ControllerButton.Grip))
            {
                if(toDelete.GetComponent<ViewLink>() != null)
                {
                    vml.DeleteLink(toDelete.GetComponent<ViewLink>().binding);
                    Debug.Log("Deleted links if any");
                } else if(toDelete.GetComponent<ViewBlock>() != null)
                {
                    vml.Delete(toDelete.GetComponent<ViewBlock>().binding);
                }
            }
            yield return null;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        toDelete = c.gameObject;
        Debug.Log(toDelete);
        StartCoroutine("CheckOnEnter");
    }

    void OnTriggerExit(Collider c)
    {
        toDelete = null;
        StopCoroutine("CheckOnEnter");
        Debug.Log("exiting..");
    }
}
