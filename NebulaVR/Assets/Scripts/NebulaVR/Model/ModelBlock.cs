using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBlock {
    private Vector3 position;
    public Vector3 Position
    {
        set
        {
            position = value;
        }
    }

    readonly ConstructInfo constructInfo;

    public ModelBlock(Vector3 position, ConstructInfo constructInfo)
    {
        this.position = position;
        this.constructInfo = constructInfo;
    }
}
