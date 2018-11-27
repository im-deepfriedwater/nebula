using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBlock: ModelConstruct
{
    private readonly HashSet<ModelComponent> components;
    bool isOrigin;

    public ModelBlock(Vector3 position, HashSet<ModelComponent> components, bool isOrigin=false)
    {
        this.Position = position;
        this.components = components;
        this.isOrigin = isOrigin;
    }
}
