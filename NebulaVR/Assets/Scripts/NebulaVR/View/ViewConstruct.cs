using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewConstruct: MonoBehaviour
{
    protected Binding binding;
    public Vector3 position
    {
        get { return gameObject.transform.position; }
    }
    abstract public void Initialize(Binding binding);
    abstract public void SignifyChange();
}
