using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawn : MonoBehaviour {
	public float spawnDistance = 3;
	public GameObject player;
	
	void Start() {
		Vector3 playerPosition = player.transform.position;
		Vector3 playerDirection = player.transform.forward;
		transform.position = playerPosition + playerDirection * spawnDistance;
	}
}
