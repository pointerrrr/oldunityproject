using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	private PlayerController playerController;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		print (collider.gameObject);
		if (collider.gameObject.tag == "Enemy"){
			Destroy(collider.gameObject);
		}
		
	}
}
