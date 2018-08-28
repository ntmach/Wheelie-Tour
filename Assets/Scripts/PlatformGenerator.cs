using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject platformType;
    public Transform generationPoint;
    private float platformWidth;

    void Start()
    {
        platformWidth = platformType.GetComponent<BoxCollider2D>().size.x - 1;
    }

    void Update () {
        //this transform.position.x is the generator
        // if the generator's position x is less than the desired generation point position x
		if(transform.position.x < generationPoint.position.x)
        {
            //creates the new platform
            Instantiate(platformType, transform.position, transform.rotation);

            // moves generator point to new desired generator point
            transform.position = new Vector3(transform.position.x 
                + platformWidth, transform.position.y, transform.position.z);
        }
	}
}
