using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float startHealth = 100;
	public float currentHealth;
	public float maxHealth;
	
	private float healthPercentage;
	
	public GameObject Bar;
	public bool healthBar = true;	
	
	private GameObject redBar;
	private GameObject greenBar;
	
	// Use this for initialization
	void Start () {
		if (healthBar){
			greenBar = Instantiate(Bar, new Vector3(transform.position.x -0.5f,transform.position.y + 0.5f,transform.position.z), Quaternion.identity) as GameObject;
			redBar = Instantiate(Bar, new Vector3(transform.position.x -0.5f,transform.position.y + 0.5f,transform.position.z), Quaternion.identity) as GameObject;

			greenBar.transform.parent = transform;
			redBar.transform.parent = transform;

			greenBar.GetComponent<SpriteRenderer>().color = Color.green;
			redBar.GetComponent<SpriteRenderer>().color = Color.red;

			greenBar.transform.name = "Green Bar";
			redBar.transform.name = "Red Bar";			


			redBar.GetComponent<SpriteRenderer>().sortingOrder= -1;
		}
		
		currentHealth = startHealth;
		maxHealth = startHealth;
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		healthPercentage = currentHealth / maxHealth;
		if (healthPercentage <= 0){
			healthPercentage = 0;
			Destroy(gameObject);
		} else if (healthPercentage >= 1){
			healthPercentage = 1;
		}
		greenBar.transform.localScale = new Vector3(healthPercentage, 1f, 1f);
		
	}
}
