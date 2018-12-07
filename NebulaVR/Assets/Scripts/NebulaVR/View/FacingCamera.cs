using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 v = player.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(player.transform.position);
        transform.Rotate(0,180,0);
    }
}
