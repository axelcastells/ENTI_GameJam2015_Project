﻿using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        Destroy(other.gameObject);

        //Debug.Log(0);
    }
}
