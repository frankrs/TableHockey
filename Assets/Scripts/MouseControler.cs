using UnityEngine;
using System.Collections;


public class MouseControler : Photon.MonoBehaviour {

	public MoveStriker moveStriker;
	public Vector2 mouseWorldPos;


	void OnEnable(){
		moveStriker = GetComponent<MoveStriker>();

		// set in position at the begining
		if(StaticShit.thisPlayer == ThisPlayer.p1){
			mouseWorldPos = new Vector2(0f,-2.5f);
		}
		if(StaticShit.thisPlayer == ThisPlayer.p2){
			mouseWorldPos = new Vector2(0f,2.5f);
		}
		moveStriker.moveVec = mouseWorldPos;
	}

	void Update () {
		//if(!photonView.isMine){
			if(Input.GetMouseButton(0)){
			mouseWorldPos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
			}
			
			// clamp pos so that it cant go through walls
			if(StaticShit.thisPlayer == ThisPlayer.p1){
				mouseWorldPos = new Vector2(Mathf.Clamp(mouseWorldPos.x,-3f,3f),Mathf.Clamp(mouseWorldPos.y,-5f,-.5f));
				}
			else{
				mouseWorldPos = new Vector2(Mathf.Clamp(mouseWorldPos.x,-3f,3f),Mathf.Clamp(mouseWorldPos.y,.5f,5f));
				}
			moveStriker.moveVec = mouseWorldPos;
			}
		//}
}
