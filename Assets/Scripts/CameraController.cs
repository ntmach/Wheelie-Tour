using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private float playerPosition;

    // has camera follow the player object.
	void Update () {
        playerPosition = player.transform.position.x;
        transform.position = new Vector3(playerPosition + 4, transform.position.y, transform.position.z);
	}
}
