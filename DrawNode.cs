﻿using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()  {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (transform.position, 0.3f);
	}
}
