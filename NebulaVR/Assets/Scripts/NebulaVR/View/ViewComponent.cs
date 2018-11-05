using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewComponent
{
    // Should keep track of the game object it's attached to.
    // Has to keep track of component links and relationships.
    // Positions in space.
    // Perhaps also the type of component it is.
    // Inputs and outputs.
    Vector3 internalPosition;
    ComponentType type;

    public void Initialize(ComponentType type)
    {
        this.type = type;
    }

    // Should be called by the controller when an object is 
    // placed. 
    void UpdateInternalModel()
    {
    }

    public enum ComponentType
    {   
        Origin,
        Function,
        Accessor,
        Return,
        Parameter
    }
}
