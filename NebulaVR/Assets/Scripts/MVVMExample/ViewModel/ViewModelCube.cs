using UnityEngine;
using UnityWeld.Binding;
using UnityEngine.UI;


[Binding]
public class ViewModelCube : MonoBehaviour {

    [SerializeField]
    private ModelEnvironment me;
    private Vector2 canvasBounds = new Vector2(225, 225);

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    public void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = me.CurrentValue;

        originalPosition = gameObject.transform.localPosition;
        originalRotation = gameObject.transform.rotation;
        originalScale = gameObject.transform.localScale;
    }

    [Binding]
    public void UpdateButton()
    {
        gameObject.GetComponentInChildren<Text>().text = me.CurrentValue;


        Vector3 newPosition = gameObject.transform.localPosition + new Vector3(me.ButtonPositionOffset, me.ButtonPositionOffset, 0);
        Vector3 newRotation = Vector3.forward * me.ButtonRotation;
        Vector3 newScale = new Vector3(me.ButtonScale, me.ButtonScale, 1);

        if (gameObject.transform.localPosition.x > canvasBounds.x || gameObject.transform.localPosition.y > canvasBounds.y)
        {
            gameObject.transform.localPosition = new Vector3(225, 225, 0);
        }

        if (gameObject.transform.localPosition.x < -canvasBounds.x || gameObject.transform.localPosition.y < -canvasBounds.y)
        {
            gameObject.transform.localPosition = new Vector3(-225, -225, 0);
        }

        gameObject.transform.localPosition = newPosition;
        gameObject.transform.localScale = newScale;
        gameObject.transform.Rotate(newRotation);

        if (me.Reset)
        {
            RestoreOriginalButtonState();
            me.Reset = false;
        }
    }

    private void RestoreOriginalButtonState()
    {
        gameObject.transform.localPosition = originalPosition;
        gameObject.transform.rotation = originalRotation;
        gameObject.transform.localScale = originalScale;
    }
}
