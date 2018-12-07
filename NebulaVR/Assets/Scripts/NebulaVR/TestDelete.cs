using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelete : MonoBehaviour {

    [SerializeField]
    ViewModelLayer vml;
	// Use this for initialization
	void Start () {
        vml.ConstructAndBindViewBlock(new Vector3(1,0,1), PremadeBlock.AddFunction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
