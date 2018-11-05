using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBlock : ViewConstruct
{
    private LinkedList<ViewComponent> components;
    override public void Initialize(Binding binding)
    {
        this.binding = binding;
    }

    // This should be called whenever the environment is modified.
    override public void SignifyChange()
    {
        this.binding.PropagateChange();
    }
}
