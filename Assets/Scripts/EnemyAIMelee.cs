using UnityEngine;
using System.Collections;

public class EnemyAIMelee : MonoBehaviour
{
	private Rigidbody2D rigid;
	private GameObject player;
	
	private float speedx, speedy, asdf;
	
	private float distance;

	private int walkingD;

	private Vector2 distanceVector;

	private bool roam = false;
	
	private bool canWalk = true;
	
	public float aiSpeed = 15f;
	
	// Use this for initialization
	void Start ()
	{
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		if (!rigid) {
			print ("no rigidbody attached to " + this.transform.name);
			Destroy (this);
		}
		
		player = GameObject.Find ("MChar01");
	}
	
	// Update is called once per frame
	void Update ()
	{
		distance = Vector2.Distance (gameObject.transform.position, player.transform.position);
		
		distanceVector = player.transform.position - transform.position;		
		
		speedx = distanceVector.x / (Mathf.Abs (distanceVector.x) + Mathf.Abs (distanceVector.y));
		speedy = distanceVector.y / (Mathf.Abs (distanceVector.x) + Mathf.Abs (distanceVector.y));
		
		if (distance <= 3f && distance > 1f) {
			rigid.velocity = new Vector2 (speedx * aiSpeed * Time.deltaTime, speedy * aiSpeed * Time.deltaTime);
		} else if (distance <= 1f) {
			rigid.velocity = Vector2.zero;
		} else {
			if (gameObject.transform.position.x % 1 < 0.01f && gameObject.transform.position.y % 1 < 0.01f)
				Roam (true);
			else
				Roam (false);
		}
	}

	void Roam (bool newD)
	{
		
		int random = Random.Range (1, 10);
		if (newD) {
			if (random == 1) {
				walkingD = 0;
			} else if (random == 2) {
				walkingD = 1;
			} else if (random == 3) {
				walkingD = 2;
			} else if (random == 4) {
				walkingD = 3;
			} else if (random == 5) {
				walkingD = 0;
			} else if (random == 6) {
				walkingD = 1;
			} else if (random == 7) {
				walkingD = 2;
			} else if (random == 8) {
				walkingD = 3;
			} else if (random == 9) {
				walkingD = 4;
			} else if (random == 10) {
				walkingD = 4;
			}
		}
		Walk ();
	}

	void Follow ()
	{
	
	}

	void Walk ()
	{
		if (walkingD == 0) {
			Vector2 currentPos = transform.position;
			canWalk = false;
			GameObject walk = new GameObject ("Distance walked");
			walk.AddComponent<Rigidbody2D> ();
			walk.transform.parent = transform;
			rigid.velocity = Vector2.down * aiSpeed * Time.deltaTime;
				
			if (transform.position.y >= (currentPos.y - 3f)) {
				Destroy (walk);
			}
			if (!walk) {
				canWalk = true;
			}
		} else if (walkingD == 1) {		
			Vector2 currentPos = transform.position;
			canWalk = false;
			GameObject walk = new GameObject ("Distance walked");
			walk.AddComponent<Rigidbody2D> ();
			walk.transform.parent = transform;
			rigid.velocity = Vector2.left * aiSpeed * Time.deltaTime;
				
			if (transform.position.x >= (currentPos.x - 3f)) {
				Destroy (walk);
			}
			if (!walk) {
				canWalk = true;
			}
		} else if (walkingD == 2) {
			Vector2 currentPos = transform.position;
			canWalk = false;		
			GameObject walk = new GameObject ("Distance walked");
			walk.AddComponent<Rigidbody2D> ();
			walk.transform.parent = transform;
			rigid.velocity = Vector2.up * aiSpeed * Time.deltaTime;
				
			if (transform.position.y >= (currentPos.y - 3f)) {
				Destroy (walk);
			}
			if (!walk) {
				canWalk = true;
			}
		} else if (walkingD == 3) {
			Vector2 currentPos = transform.position;
			canWalk = false;		
			GameObject walk = new GameObject ("Distance walked");
			walk.AddComponent<Rigidbody2D> ();
			walk.transform.parent = transform;
			rigid.velocity = Vector2.right * aiSpeed * Time.deltaTime;
				
			if (transform.position.y >= (currentPos.y - 3f)) {
				Destroy (walk);
			}
			if (!walk) {
				canWalk = true;
			}
		} else if (walkingD == 4) {
			Vector2 currentPos = transform.position;
			canWalk = false;
			GameObject walk = new GameObject ("Distance walked");
			walk.AddComponent<Rigidbody2D> ();
			walk.transform.parent = transform;
			walk.GetComponent<Rigidbody2D> ().velocity = Vector2.down * aiSpeed * Time.deltaTime;
			if (!walk) {
				canWalk = true;
			}
		}
	}
		
}

