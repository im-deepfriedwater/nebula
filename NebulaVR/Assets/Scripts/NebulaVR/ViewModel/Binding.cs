using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Binding
{
    ViewBlock vb;
    ModelBlock mb;
    UnityEvent environmentChanged;

    public Binding(ViewBlock vb, ModelBlock mb, UnityEvent viewModelEvent)
    {
        this.vb = vb;
        this.mb = mb;
        environmentChanged = viewModelEvent;
    }

    public void PropagateChange()
    {
        TranslatePositionFromViewToModel();
        this.environmentChanged.Invoke();
    }

    private void TranslatePositionFromViewToModel()
    {
        throw new System.NotImplementedException();
    }
}
