using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestValue : MonoBehaviour {

    public string value;
	// Use this for initialization
	void Start () {
        value = "hello";
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(value);
	}
}
