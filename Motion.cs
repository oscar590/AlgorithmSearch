using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NavMeshAgent))]
public class Motion : MonoBehaviour {

	CharacterController cc;
	NavMeshAgent agent;

	public Transform target;

	public Vector3 objective;

	// Use this for initialization
	void Start () {
	
		cc = GetComponent<CharacterController> ();
		agent = GetComponent<NavMeshAgent> ();
		objective = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//cc.Move (new Vector3 (h, 0, v) * Time.deltaTime);
		//cc.SimpleMove(new Vector3(h, 0, v));

		if (!cc.isGrounded) {
		
			Debug.Log ("FREE FALLIN");
		}

		if (Input.GetMouseButtonUp (0)) {

			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(mouseRay, out hit)){

				objective = hit.point;
			}
		}

		agent.destination = objective;
	}

	void OnControllerColliderHit(ControllerColliderHit c) {
	
		//Debug.Log (c.transform.name);
	}
}
