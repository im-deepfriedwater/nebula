﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewConstruct: MonoBehaviour
{
    public Vector3 Position
    {
        get { return gameObject.transform.position; }
    }
    abstract public void SignifyChange();
    abstract public void Delete();
}