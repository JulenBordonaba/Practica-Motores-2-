﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirartarget : MonoBehaviour {
  //  public Transform target;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(0, 0, 0));
    }
}
