using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class ViewPropagateBehaviour : MonoBehaviour
{
    [SerializeField]
    HandRole selectedHand;
    [SerializeField]
    ViewModelLayer vml;

    GameObject toAccessBinding;

    IEnumerator CheckOnEnter()
    {
        while (true)
        {
            if(toAccessBinding != null && ViveInput.GetPressUp(selectedHand, ControllerButton.Trigger))
            {
                if(toAccessBinding.GetComponent<ViewBlock>() != null)
                {
                    toAccessBinding.GetComponent<ViewBlock>().SignifyChange();
                }
                else if(toAccessBinding.GetComponent<ViewComponent>() != null)
                {
                    toAccessBinding.GetComponent<ViewComponent>().SignifyChange();
                }
            }

            yield return null;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        toAccessBinding = c.gameObject;
        StartCoroutine("CheckOnEnter");
    }

    void OnTriggerExit(Collider c)
    {
        toAccessBinding = null;
        StopCoroutine("CheckOnEnter");
    }
}
