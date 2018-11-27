using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLink
{
    Vector3 to;
    Vector3 from;
    public ModelLink(Vector3 to, Vector3 from)
    {
        this.to = to;
        this.from = from;
    }
}
