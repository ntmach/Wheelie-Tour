using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    public GameObject platformDestructionPoint;

	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	// Destroys current game object when this object x position is less than destruction point x position
	void Update () {
		if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
