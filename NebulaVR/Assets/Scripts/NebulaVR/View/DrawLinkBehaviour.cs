using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinkBehaviour : MonoBehaviour {
    [SerializeField]
    Color currentColor;
    LineRenderer lr;
    GameObject mom;
    GameObject dad;
    Vector3 momPos;
    Vector3 dadPos;

    void Update()
    {
        if(mom.transform.position == null)
        {
            lr.SetPosition(0, momPos);
        } else if(dad.transform.position == null)
        {
            lr.SetPosition(1, dadPos);
        }
        else
        {
            lr.SetPosition(0, mom.transform.position);
            lr.SetPosition(1, dad.transform.position);
            momPos.Set(mom.transform.position.x, mom.transform.position.y, mom.transform.position.z);
            dadPos.Set(dad.transform.position.x, dad.transform.position.y, dad.transform.position.z);
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
