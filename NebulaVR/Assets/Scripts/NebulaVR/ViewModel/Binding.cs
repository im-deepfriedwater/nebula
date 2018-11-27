using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Binding
{
    readonly ViewBlock vb;
    readonly ModelBlock mb;
    readonly UnityEvent environmentChanged;
    readonly Dictionary<ViewComponent, ModelComponent> components;

    public Binding(ViewBlock vb, ModelBlock mb, UnityEvent viewModelEvent)
    {
        this.vb = vb;
        this.mb = mb;
        environmentChanged = viewModelEvent;

        components = new Dictionary<ViewComponent, ModelComponent>();

        foreach (ViewComponent in vb.components)
        {
            throw new System.NotImplementedException();
        }
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
