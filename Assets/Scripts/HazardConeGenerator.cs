using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HazardConeGenerator : MonoBehaviour {
    public GameObject hazardObject;
    public GameObject player;
    public Transform coneGeneratorPoint;
    public float coneSpawnDistance;
    private int number;
    private float yPosition;
    System.Random rand = new System.Random();

    // Update is called once per frame
    void Update () {
		if (transform.position.x < coneGeneratorPoint.position.x)
        {
            pick();

            Instantiate(hazardObject, transform.position, transform.rotation);

            transform.position = new Vector3(transform.position.x
                + coneSpawnDistance, yPosition, transform.position.z);
        }
	}

    // number generator decides which lane cone will spawn.
    void pick()
    {
        number = rand.Next(6);

        if(number == 1 || number == 4)
        {
            yPosition = (float) -.2;
        }

        else if(number == 2 || number == 5)
        {
            yPosition = (float) -2.3;
        }

        else if(number == 3 || number == 6)
        {
            yPosition = (float) -4.4;
        }
    }
}
