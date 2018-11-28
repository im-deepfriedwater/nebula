using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBlock : ViewConstruct
{   
    [SerializeField]
    public readonly string id;

    public void Initialize(Binding binding)
    {
        this.binding = binding;
    }
     
    // This should be called whenever this block is modified.
    override public void SignifyChange()
    {
        this.binding.PropagateChange();
    }

    public override void Delete()
    {
        Object.Destroy(this.gameObject);
    }
}
