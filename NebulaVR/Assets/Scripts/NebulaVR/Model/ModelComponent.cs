using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelComponent {
    private readonly ComponentType componentType;
    private readonly List<ModelLink> links;
    private readonly Vector3 position;

    public ModelComponent(ComponentType componentType, Vector3 position)
    {
        this.componentType = componentType;
        this.position = position;
        this.links = new List<ModelLink>();
    }
}
