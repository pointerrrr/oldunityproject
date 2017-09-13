using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static GameControl control;
	
	//Player variables with their defaults
	public Vector2 playerPosition = new Vector2 (0f, 0f);
	public float playerWalkSpeed = 2f;
	public int playerDirection = 0;
	
	public float currentHealth = 100f;
	public float maxHealth = 100f;
	
	
	
	void Awake(){
		//Making sure this is the only GameControl
		if(control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this){
			Destroy(gameObject);		
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Scene Managing
	public void LoadScene(string name){
		//Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
}
