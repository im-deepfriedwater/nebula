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

    [SerializeField]
    private ComponentType type;

    // This is for programmatically generating a component. TODO for now.
    //public void Initialize(ComponentType type, ViewBlock parent, Vector3 position)
    //{
    //    this.type = type;
    //    this.parent = parent;
    //    this.internalPosition = position;
    //} 

    // Should be called by the controller when a component is moved.
    override public void SignifyChange()
    {
        this.UpdateInternals();
        parent.SignifyChange();
    }

    void LinkComponent(ViewLink link)
    {
        this.link = link;
        this.SignifyChange();
    }

    private void UpdateInternals()
    {
        // TODO internalPosition needs to be updated
    }
}

public enum ComponentType
{
    Origin,
    Function,
    Accessor,
    Return,
    Parameter
}
