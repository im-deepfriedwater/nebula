using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelComponent: ModelConstruct {
    private readonly ComponentType componentType;
    private readonly HashSet<ModelLink> links;

    public ModelComponent(ComponentType componentType, Vector3 position)
    {
        this.componentType = componentType;
        this.Position = position;
        this.links = new HashSet<ModelLink>();
    }
}
