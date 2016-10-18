using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Path : MonoBehaviour {

	public Node start;
	public Node end;
	public float threshold;
	//public List<Node> nodes;
	private List<Node> path;
	private List<Node> myPath;
	private int currentNode;
	private Node[] nodesList;
	public int speed;


	public Vector3 objective;


	// Use this for initialization
	void Start () {

		//objective = this.transform.position;
		nodesList = start.nodes[1].nodes;

		path = AlgorithmPath.DepthwiseSearch (start, end);

		myPath = new List<Node> (path);

	}

	Node GetNode(RaycastHit ray) {
		objective = ray.point;
		Dictionary<int, float> distances = new Dictionary<int, float> ();
		//var allNodes = start.nodes [1].nodes;
		var allNodes = nodesList;
		for (int i = 0; i < allNodes.Length; i++) {
			//Debug.Log (Vector3.Distance (objective, allNodes [i].transform.position));
			distances.Add (i, Vector3.Distance (objective, allNodes [i].transform.position));
		}
		var closestNode = distances.OrderBy (keyPair => keyPair.Value).Select (key => key.Key).First();
		//Debug.Log (allNodes[closestNode].name);
		return allNodes[closestNode];
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				//myPath = new List<Node> ();
				if (myPath.Count == 0) {
					Debug.Log ("New list");
				}

				Debug.Log ("CurrentNode " + currentNode);
				end = GetNode (hit);
				Debug.Log (GetNode (hit).name);

			}
		} 

		Debug.Log ("End " + end.name);
		path = AlgorithmPath.DepthwiseSearch (start, end);
		myPath = new List<Node> (path);

		transform.LookAt (myPath [currentNode].transform);
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

		float distance = Vector3.Distance(myPath[currentNode].transform.position, transform.position);
		if(distance < threshold) {
			currentNode++;
			//Debug.Log ("CurrentPlus " + currentNode);
			currentNode %= myPath.Count;
			//Debug.Log ("Current " + currentNode);
		}


	}
}
