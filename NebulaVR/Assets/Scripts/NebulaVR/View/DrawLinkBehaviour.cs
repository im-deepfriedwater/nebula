using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinkBehaviour : MonoBehaviour {
    [SerializeField]
    Color currentColor;
    LineRenderer lr;
    public GameObject mom;
    public GameObject dad;

    void Update()
    {
        if (mom == null || dad == null)
        {
            Destroy(gameObject);
            Debug.Log(mom == null);
            Debug.Log(dad == null);
        }
        else
        {
            lr.SetPosition(0, mom.transform.position);
            lr.SetPosition(1, dad.transform.position);
            gameObject.GetComponent<ViewLink>().binding.PropagateChange();
        }
    }

    public void Initialize(GameObject start, GameObject end)
    {
        mom = start;
        dad = end;
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startWidth = 0.1f;
        lr.startColor = currentColor;
        lr.endColor = currentColor;
        lr.SetPosition(0, start.transform.position);
        lr.SetPosition(1, end.transform.position);
        Debug.Log("Drawing new line at " + start.transform.position + " " + end.transform.position);
    }
}
