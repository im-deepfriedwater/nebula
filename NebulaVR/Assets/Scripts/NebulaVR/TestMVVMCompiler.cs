using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMVVMCompiler : MonoBehaviour {
    [SerializeField]
    ViewModelLayer vml;

    [SerializeField]
    GameObject prefabBlock;


	// Use this for initialization
	void Start ()
    {
        vml.ConstructAndBindViewBlock(new Vector3(2, 0, 0), prefabBlock);
        vml.ConstructAndBindViewLink(new Vector3(10, 0, 10), new Vector3(11, 0, 11));
    }
	
}
