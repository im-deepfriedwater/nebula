using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScript : MonoBehaviour {

    VirtualKeyboard vk = new VirtualKeyboard();

    public void OpenKeyboard()
    {
        {
            vk.ShowTouchKeyboard();
        }
    }

    public void CloseKeyboard()
    {
        {
            vk.HideTouchKeyboard();
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
        {
            OpenKeyboard();
        } 
        if (Input.GetKeyDown("b"))
        {
            CloseKeyboard();
        }
	}
}
