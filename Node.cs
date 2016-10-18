using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public Node[] neighbors;
	public List<Node> history;
	public float f, g;

	void OnDrawGizmos(){

		Gizmos.color = Color.green;
		for (int i = 0; i < neighbors.Length; i++) {
			Gizmos.DrawLine (transform.position, neighbors [i].transform.position);
		}
	}
}
