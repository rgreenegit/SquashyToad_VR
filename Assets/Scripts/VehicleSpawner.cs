﻿using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public GameObject prefab;

    public float minTime = 2;
    public float meanTime = 1;
    float nextSpawnTime = 0;

	void Update () {
	    if (Time.time > nextSpawnTime)
        {
            Spawn();

            nextSpawnTime = Time.time + minTime - (Mathf.Log(Random.value) * meanTime);
        }
	}

    void Spawn()
    {
        //var instance = Instantiate(prefab, transform.position, transform.rotation, transform);
		Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}

