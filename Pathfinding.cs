using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding {


	// breadth
	// a lo ancho
	public static List<Node> BreadthwiseSearch(Node start, Node end){

		Queue<Node> working = new Queue<Node> ();
		List<Node> visited = new List<Node> ();

		start.history = new List<Node> ();
		working.Enqueue (start);
		visited.Add (start);

		while(working.Count > 0){

			Node currentNode = working.Dequeue ();

			if (currentNode == end) {

				// this is the end!
				List<Node> result = currentNode.history;
				result.Add (currentNode);
				return result;

			} else {
			
				for (int i = 0; i < currentNode.neighbors.Length; i++) {
				
					Node currentChild = currentNode.neighbors[i];
					// check if it hasn't been visited
					if(!visited.Contains(currentChild)){

						// update history
						currentChild.history = new List<Node>(currentNode.history);
						currentChild.history.Add (currentNode);

						// add to queue
						working.Enqueue(currentChild);

						// add to visited
						visited.Add(currentChild);

					}
				}
			}
		}

		return null;
	}

	public static List<Node> DepthwiseSearch(Node start, Node end){ 

		List<Node> visited = new List<Node> ();
		Stack<Node> stack = new Stack<Node> ();

		start.history = new List<Node> ();
		visited.Add (start);
		stack.Push (start);

		while(stack.Count > 0){ 
		
			Node current = stack.Pop ();
			if (current == end) {

				// found the final node!
				List<Node> result = current.history;
				result.Add (current);
				return result;

			} else {
			
				// not the final node

				for(int i = 0; i < current.neighbors.Length; i++) {

					Node currentNeighbor = current.neighbors [i];

					if(!visited.Contains(currentNeighbor)) {

						visited.Add (currentNeighbor);
						stack.Push (currentNeighbor);

						currentNeighbor.history = new List<Node> (current.history);
						currentNeighbor.history.Add (current);
					}
				}
			}
		}

		return null; 
	
	}
	public static List<Node> AStar(Node start, Node end){ 

		List<Node> visited = new List<Node> ();
		List<Node> work = new List<Node> ();

		visited.Add (start);
		work.Add (start);

		start.history = new List<Node> ();
		start.g = 0;
		start.f = start.g + 
			Vector3.Distance (start.transform.position, end.transform.position);

		while (work.Count > 0) {
		
			// get the best one (the smallest f)

			int smallest = 0;

			for(int i = 0; i < work.Count; i++) {
				if(work[i].f < work[smallest].f){
					smallest = i;
				}
			}

			Node smallestNode = work[smallest];

			// remove from working list
			work.Remove(smallestNode);

			if (smallestNode == end) {
				// found	
				List<Node> result = new List<Node>(smallestNode.history);
				result.Add (smallestNode);
				return result;

			} else {

				// not found
				for(int i = 0; i < smallestNode.neighbors.Length; i++){
					Node currentChild = smallestNode.neighbors[i];

					if (!visited.Contains (currentChild)) {

						visited.Add (currentChild);
						work.Add (currentChild);

						// f, g, h
						currentChild.g = smallestNode.g +
						Vector3.Distance (currentChild.transform.position, 
								smallestNode.transform.position);

						float h = Vector3.Distance (currentChild.transform.position,
							          end.transform.position);

						currentChild.f = currentChild.g + h;

						// update history
						currentChild.history = new List<Node>(smallestNode.history);
						currentChild.history.Add (smallestNode);
					}
				}
			}
		}

		return null; 
	}
}
