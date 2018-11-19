using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVVMEnvironmentTest : MonoBehaviour {
    ViewModelLayer vml;
    // Use this for initialization
    public void SpawnBlock()
    {
        vml.ConstructAndBindViewBlock(new Vector3(0, 0, 0), new ConstructInfo());
    }
}
