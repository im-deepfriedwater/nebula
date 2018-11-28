using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinkBehaviour : MonoBehaviour {
    [SerializeField]
    Color currentColor;
    LineRenderer lr;

    void UpdateLine(Vector3 start, Vector3 end)
    {
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public void Initialize(Vector3 start, Vector3 end)
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetWidth(0.1f, 0.1f);
        lr.startColor = currentColor;
        lr.endColor = currentColor;
        this.transform.position = start;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}
