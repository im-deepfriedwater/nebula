using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Binding
{
    readonly ViewBlock vb;
    readonly ModelBlock mb;
    readonly UnityEvent environmentChanged;

    public Binding(ViewBlock vb, ModelBlock mb, UnityEvent viewModelEvent)
    {
        this.vb = vb;
        this.mb = mb;
        environmentChanged = viewModelEvent;
    }

    public void PropagateChange()
    {
        this.environmentChanged.Invoke();
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        this.vb.Delete();
        me.RemoveBlock(this.mb);
    }
}
