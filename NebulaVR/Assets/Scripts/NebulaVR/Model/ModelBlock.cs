using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBlock {
    private readonly List<ModelComponent> components;
    private readonly string id;
    private Vector3 position;
    public Vector3 Position
    {
        set
        {
            position = value;
        }
    }

    public ModelBlock(Vector3 position, List<ModelComponent> components)
    {
        this.position = position;
        this.components = components;
    }
}
