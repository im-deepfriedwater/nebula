using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetScript : MonoBehaviour {
    private ReticlePoser reticlePoser;
    public GameObject otherGameObject;
    // Use this for initialization
    void Start ()
    {
        reticlePoser = otherGameObject.GetComponent<ReticlePoser>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        reticlePoser = otherGameObject.GetComponent<ReticlePoser>();
        // Debug.Log(reticlePoser.hitTarget.tag);

        if(reticlePoser.hitTarget.tag == "Initialize")
        {
            Debug.Log("HOWDY");
        }
    }
}
