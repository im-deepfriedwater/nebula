using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayConsoleScript : MonoBehaviour {

    string value;
    public Text currentText;

	// Update is called once per frame
	void Update () {
        //currentText.text = value;
	}

    void setValue(string val)
    {
        value = val;
    }

    string getValue()
    {
        return value;
    }
}
