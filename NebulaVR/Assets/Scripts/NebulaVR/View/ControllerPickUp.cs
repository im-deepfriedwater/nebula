using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HTC.UnityPlugin.Vive;

public class ControllerPickUp : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerDownHandler
    , IPointerUpHandler
{
    private HashSet<PointerEventData> hovers = new HashSet<PointerEventData>();
    public GameObject reticuleSphere;
    private bool isPickedUp = false;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Raycast has hit a game object");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Raycast is no longer hittng a game object");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPickedUp = eventData.IsViveButton(ControllerButton.Trigger);
        Debug.Log(isPickedUp);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPickedUp = false;
        Debug.Log(isPickedUp);
    }

    void Update()
    {

        if (isPickedUp)
        {
            gameObject.transform.position = new Vector3(
                reticuleSphere.transform.position.x,
                reticuleSphere.transform.position.y,
                reticuleSphere.transform.position.z
            );

        }
    }

}
