using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetScript : MonoBehaviour {
    private ReticlePoser reticlePoser;
    public GameObject otherGameObject;
    public GameObject keyboard;

	
    void OnEnable()
    {
        reticlePoser = otherGameObject.GetComponent<ReticlePoser>();
        if (keyboard.activeSelf)
        {
            keyboard.SetActive(false);
        }
        else if (reticlePoser.hitTarget.tag == "Initialize")
        {
            keyboard.SetActive(true);
            Debug.Log(keyboard.GetComponent<AllButtonsMockScript>().typed);
        }
    }

    void OnDisable()
    {
        //reticlePoser.hitTarget.____ = keyboard.GetComponent<AllButtonsMockScript>().typed;
        reticlePoser.hitTarget.GetComponent<TestValue>().value = keyboard.GetComponent<AllButtonsMockScript>().typed;

    }
}
