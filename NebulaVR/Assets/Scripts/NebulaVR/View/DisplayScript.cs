using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour {

    public Text currentText;
    public GameObject keyboard;
    void Update ()
    {
        currentText.text = keyboard.GetComponent<AllButtonsMockScript>().typed;
    }
}
