using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlgorithmPath : MonoBehaviour {


	public static List<Node> DepthwiseSearch(Node start, Node end){ 

		List<Node> visited = new List<Node> ();
		Stack<Node> stack = new Stack<Node> ();

		visited.Add (start);
		stack.Push (start);

		while(stack.Count > 0) {
			Node current = stack.Pop ();

			if (current == end) {
				//found the final node
				List<Node> result = current.list;
				result.Add (current);
				return result;

			} else {
				//not the final node
				for(int i = 0; i < current.nodes.Length; i++) {
					Node currentNeighbor = current.nodes [i];
					if(!visited.Contains(currentNeighbor)) {
						visited.Add (currentNeighbor);
						stack.Push (currentNeighbor);

						currentNeighbor.list = new List<Node> (current.list);
						currentNeighbor.list.Add (current);
					}

				}
			}
		}

		return null; 
	}


}
