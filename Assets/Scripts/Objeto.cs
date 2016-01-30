using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour {
	
	
		void OnCollisionEnter2D(Collision2D colisor){
				if (colisor.gameObject.tag == "Player") {
						var player = colisor.gameObject.GetComponent <Player> ();
						Destroy (gameObject);
				}

		}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
