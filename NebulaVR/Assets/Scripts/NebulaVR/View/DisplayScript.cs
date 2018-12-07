using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour {

    public Text currentText;
    void Update ()
    {
        currentText.text = AllButtonsMockScript.typed;
    }
}
