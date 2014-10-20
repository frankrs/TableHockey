using UnityEngine;
using System.Collections;
using Photon;

public class MoveStriker : Photon.MonoBehaviour {


	public Vector2 moveVec;

	void Awake(){
	// apply mouse control if its apropriate
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer
		   || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer
		   || Application.platform == RuntimePlatform.LinuxPlayer){
			if(photonView.isMine){
			gameObject.AddComponent<MouseControler>();
			}
		}
	}


	void FixedUpdate () {
		rigidbody2D.MovePosition(moveVec);
	}


//	void Update(){
//		if(!photonView.isMine){
//			moveVec = Vector2.Lerp(transform.position,realPos,.1f);
//		}
//	}



	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(moveVec);
			
		}
		else
		{
			//realMoveVec = (Vector2)stream.ReceiveNext();
			moveVec = (Vector2)stream.ReceiveNext();

		}
	}





}
