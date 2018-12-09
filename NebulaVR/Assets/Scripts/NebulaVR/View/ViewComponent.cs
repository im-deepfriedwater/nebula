using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewComponent: ViewConstruct
{
    // Should keep track of the game object it's attached to.
    // Has to keep track of component links and relationships.
    // Positions in space.
    // Perhaps also the type of component it is.
    // Inputs and outputs.
    ViewBlock parent;
    Vector3 internalPosition; // NOTE: This is relative to the parent.
    ViewLink link;
    public ComponentBinding binding;
    [SerializeField]
    public ComponentType componentType;
    public int InitializedValue;

    public void Initialize(ViewBlock parent, ComponentBinding binding)
    {
        this.parent = parent;
        this.binding = binding;
    }

    public void SetInitialize(int value)
    {
        InitializedValue = value;
    }

    // Should be called by the controller when a component is moved.
    override public void SignifyChange()
    {
        UpdateInternals();
        binding.PropagateChange();
        parent.SignifyChange();
    }

    void LinkComponent(ViewLink link)
    {
        this.link = link;
        SignifyChange();
    }

    private void UpdateInternals()
    {
        this.internalPosition = gameObject.transform.localPosition;
    }

    public override void Delete()
    {
        Destroy(gameObject);
    }
}

public enum ComponentType
{
    Origin,
    Function,
    Accessor,
    Return,
    Parameter,
    Input
}
