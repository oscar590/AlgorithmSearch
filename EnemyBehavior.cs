using UnityEngine;
using System.Collections;
using Random=UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour {

	public Transform spawnPoint;
	public float time;
	//int spawn = Random.Range(0,4);
	// Use this for initialization
	void Start () {
		Invoke ("spawnEnemy", time);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(spawn);
		movement ();
	}

	void OnTriggerEnter(Collider c) {
		Destroy (c.gameObject);
		Destroy (this.gameObject);


	}

	void spawnEnemy()  {
		//Random rnd = new Random ();
		//Debug.Log(spawn);
		//Transform restart = spawnPoint[spawn];
		Instantiate (this.gameObject, spawnPoint.position, Quaternion.identity);
		//yield return new WaitForSeconds(2);
	}	

	void movement() {
		transform.Translate (new Vector3(spawnPoint.position.x * Time.deltaTime * -0.9f, 0, 0));
	}


}
