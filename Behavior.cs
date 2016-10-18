using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Behavior : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		transform.Translate (-v*Time.deltaTime*5, h*Time.deltaTime*5, 0);

	
		if(Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("Sapce");
			Fire ();
		}

		if(Input.GetKeyDown(KeyCode.J)) {
			restartScene ();
		}
	}

	void Fire() {
		var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
		//bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 6;
		bullet.GetComponent<Rigidbody>().AddForce(700,0,0);
		Destroy(bullet, 2.0f);
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("scene");
		restartScene ();
	}

	void restartScene() {
		//int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (0);
	}
}
