using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
	//Amount of LoadLocations
	public int entryCount = 0;
	public static int entry = 0;
	
	public GameObject loadingZone;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddBank(){
		if (loadingZone != null){
			GameObject mapBank;
			mapBank = Instantiate(loadingZone, Vector3.zero, Quaternion.identity) as GameObject;
			mapBank.transform.parent = gameObject.transform;
			mapBank.transform.name = "LoadingZone";
		}
	}
}
