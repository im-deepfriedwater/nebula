using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelConstruct {
    private Vector3 position;
    public Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

}
