using UnityEngine;
using System.Collections;
using Photon;

public class SetUpGame : Photon.MonoBehaviour {
	public GameObject striker;

//	void OnLevelWasLoaded (){
//		// wait for other player to join level
//		//while(PhotonNetwork.
//
//		// create striker object
//		if(StaticShit.thisPlayer == ThisPlayer.p1){
//			PhotonNetwork.Instantiate("striker",new Vector3(0f,-2.5f,0f),Quaternion.identity,0);
//		}
//		if(StaticShit.thisPlayer == ThisPlayer.p2){
//			PhotonNetwork.Instantiate("striker",new Vector3(0f,2.5f,0f),Quaternion.identity,0);
//		}
//		// crate puck
//		if(PhotonNetwork.isMasterClient){
//			PhotonNetwork.InstantiateSceneObject("Puck",new Vector3(0f,0f,0f),Quaternion.identity,0,null);
//		}
//	}



	void OnLevelWasLoaded (){
		PhotonNetwork.JoinOrCreateRoom("Random",null,null);
	}


	void OnJoinedRoom (){
		if(PhotonNetwork.isMasterClient){
			StaticShit.thisPlayer = ThisPlayer.p1;
		}
		else{
			StaticShit.thisPlayer = ThisPlayer.p2;
		}
		StartCoroutine("WaitForOpponent");
	}


	IEnumerator WaitForOpponent(){
		while(PhotonNetwork.room.playerCount<2){
			yield return new WaitForEndOfFrame();
		}
		// create striker object
		if(StaticShit.thisPlayer == ThisPlayer.p1){
			GameObject striker = PhotonNetwork.Instantiate("striker",new Vector3(0f,-2.5f,0f),Quaternion.identity,0);
			striker.AddComponent<MoveStriker>();
		}
		if(StaticShit.thisPlayer == ThisPlayer.p2){
			GameObject striker = PhotonNetwork.Instantiate("striker",new Vector3(0f,2.5f,0f),Quaternion.identity,0);
			striker.AddComponent<MoveStriker>();
		}
		// crate puck
		if(PhotonNetwork.isMasterClient){
			PhotonNetwork.InstantiateSceneObject("Puck",new Vector3(0f,0f,0f),Quaternion.identity,0,null);
		}

	}





}
