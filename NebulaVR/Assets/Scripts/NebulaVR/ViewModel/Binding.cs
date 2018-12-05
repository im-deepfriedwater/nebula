﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Could make it take in two generic types.
public class Binding
{
    public readonly ViewBlock vb;
    public readonly ModelBlock mb;
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
        vb.Delete();
        mb.Delete();
        me.RemoveBlock(this.mb);
    }
}