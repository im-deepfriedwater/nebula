﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelConstruct {

    private string id;
    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = Id;
        }
    }
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
