using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathTest : MonoBehaviour {

	public Node start;
	public Node end;
	public float threshold;

	private List<Node> myPath;
	private int currentNode;

	// Use this for initialization
	void Start () {

		Debug.Log ("********************************* DEPTHWISE");
		List<Node> path = Pathfinding.DepthwiseSearch (start, end);
		for (int i = 0; i < path.Count; i++) {
		
			Debug.Log (path [i].transform.name);
		}


		
		Debug.Log ("********************************* BREADTHWISE");

		path = Pathfinding.BreadthwiseSearch (start, end);
		for (int i = 0; i < path.Count; i++) {

			Debug.Log (path [i].transform.name);
		}



		Debug.Log ("********************************* A*");

		path = Pathfinding.AStar(start, end);
		for (int i = 0; i < path.Count; i++) {

			Debug.Log (path [i].transform.name);
		}

		myPath = new List<Node> (path);
		currentNode = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		// 2 things here ONLY
		// - motion (as smooth as possible)
		// - input (as responsive as possible)
		transform.LookAt (myPath [currentNode].transform);
		transform.Translate (transform.forward * 5 * Time.deltaTime, Space.World);

		// this is not OK.
		float distance = Vector3.Distance (myPath [currentNode].transform.position,
			                 transform.position);

		if(distance < threshold){

			currentNode++;
			currentNode %= myPath.Count;
		}
	}
}
