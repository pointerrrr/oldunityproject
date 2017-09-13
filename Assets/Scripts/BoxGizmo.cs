using UnityEngine;
using System.Collections;

public class BoxGizmo : MonoBehaviour {
	
	public float gizmox = 0f, gizmoy = 0f;
	public float gizmowidth = 1f, gizmoheigth = 1f;
	
	public enum gizmoType{defaultGizmo, loadingZone, collisionBox};	
	public gizmoType typeOfGizmo;
	
	public Color colorOfGizmo = Color.white;
	
	public bool shaded = false;	
	
	private Color colorLoadingZone = new Color(0f, 0.6f, 1f, 0.5f);
	private Color colorCollisionBox = new Color(0.6745f, 0.9686f, 0.6588f, 1f);
	
	private Vector2 gizmoPosition;
		
	void OnDrawGizmos(){
		gizmoPosition = new Vector3(transform.position.x + 0.5f + gizmox, transform.position.y + 0.5f + gizmoy);
		
		if(typeOfGizmo == gizmoType.defaultGizmo){
			Gizmos.color = colorOfGizmo;
			drawCube(shaded);
			Gizmos.color = colorOfGizmo;
		}
		if (typeOfGizmo == gizmoType.loadingZone){
			Gizmos.color = colorLoadingZone;
			drawCube(true);
			Gizmos.color = colorLoadingZone;
			colorOfGizmo = colorLoadingZone;
			shaded = true;
		}
		if (typeOfGizmo == gizmoType.collisionBox){
			Gizmos.color = colorCollisionBox;
			drawCube(false);
			Gizmos.color = colorCollisionBox;
			colorOfGizmo = colorCollisionBox;
			shaded = false;
		}
		
		
		//Gizmos.DrawWireCube(gizmoPosition, new Vector2(gizmowidth, gizmoheigth));
	}
	
	void drawCube(bool isShaded){
		if (isShaded){
			Gizmos.DrawCube(gizmoPosition, new Vector3(gizmowidth, gizmoheigth));
		} else {
			Gizmos.DrawWireCube(gizmoPosition, new Vector3(gizmowidth, gizmoheigth));
		}
	}
}
