using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapManager))]
public class MapManagerInspector : Editor {
	private int entryCount = 0;
		
	public override void OnInspectorGUI(){
		MapManager mapManager = (MapManager)target;
		
		entryCount = mapManager.transform.childCount;
			
		Rename ();
		
		EditorGUILayout.LabelField("Loading Zones", entryCount.ToString());
		
		//Button to add a LoadingZone
		if(GUILayout.Button("Add Loading Zone")){
			mapManager.AddBank();
		}	
	}
	
	//Rename all object called LoadingZone to LoadingZone x
	void Rename(){
		MapManager mapManager = (MapManager)target;
		entryCount = mapManager.transform.childCount;
		foreach(Transform child in mapManager.transform){
			if (child.transform.name == "LoadingZone"){
				child.transform.name = "LoadingZone " + FindFreeSpot().ToString();
			}
		}
	}
	
	//Find the first next not used LoadingZone x
	int FindFreeSpot(){
		int returnEntry = 0;
		
		MapManager mapManager = (MapManager)target;
		entryCount = mapManager.transform.childCount;
		
		int loop = 0;
		while (loop < entryCount){
			foreach (Transform child in mapManager.transform){
				if (child.transform.name == "LoadingZone " + returnEntry.ToString()){
					returnEntry += 1;
				}
			
			}
			loop += 1;
		}
		
		return returnEntry;
	}
}

