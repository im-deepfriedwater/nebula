using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour {

    public Text currentText;
    // Update is called once per frame
    void Update () {
        Debug.Log(AllButtonsMockScript.typed);
        currentText.text = AllButtonsMockScript.typed;

    }
}
