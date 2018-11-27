using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawn : MonoBehaviour {
	public float spawnDistance;
	public GameObject player;
	
	void Start() {
		Vector3 playerPosition = player.transform.position;
		Vector3 playerDirection = player.transform.forward;
		transform.position = playerPosition + playerDirection * spawnDistance;
	}

	void Update() {
	}

	void OnEnable()
    {
		Vector3 playerPosition = player.transform.position;
		Vector3 playerDirection = player.transform.forward;
		transform.position = playerPosition + playerDirection * spawnDistance;
    }
	void OnDisable()
    {
    }
	
}
