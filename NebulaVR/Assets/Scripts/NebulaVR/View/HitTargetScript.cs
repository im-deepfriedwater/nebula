using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetScript : MonoBehaviour {
    private ReticlePoser reticlePoser;
    public GameObject reticle;
    public GameObject keyboard;

    void OnEnable()
    {
        reticlePoser = reticle.GetComponent<ReticlePoser>();
        /*if (keyboard.activeSelf)
        {
            keyboard.SetActive(false);
        }
        else*/
        if(reticlePoser.hitTarget != null)
        {
            if (reticlePoser.hitTarget.tag == "Initialize")
            {
                keyboard.SetActive(true);
                // Debug.Log(keyboard.GetComponent<AllButtonsMockScript>().typed);
            }
        }
        
    }

    void OnDisable()
    {
        //reticlePoser.hitTarget.____ = keyboard.GetComponent<AllButtonsMockScript>().typed;
        if(reticlePoser.hitTarget.GetComponent<ViewComponent>() != null)
        {
            reticlePoser.hitTarget.GetComponent<ViewComponent>().InitializeValue = keyboard.GetComponent<AllButtonsMockScript>().typed;
        }
        keyboard.SetActive(false);
    }
}
