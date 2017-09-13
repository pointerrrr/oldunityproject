using UnityEngine;
using System.Collections;

public class LoadingZone : MonoBehaviour {
	public string loadLocation = "Win Screen";
	
	public float loadLocationx = 1f, loadLocationy = 1f;
	
	public int inputDirection = 2;
	public int outputDirection = 0;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerStay2D(Collider2D character){
		if (PlayerController.space && character.tag == "Player" && inputDirection == PlayerController.direction){
			GameControl.control.playerPosition = new Vector2 (loadLocationx, loadLocationy);
			print(GameControl.control.playerPosition);
			GameControl.control.playerDirection = outputDirection;
			GameControl.control.LoadScene(loadLocation);			
		}
	}
}
