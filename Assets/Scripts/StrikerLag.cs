using UnityEngine;
using System.Collections;

public class StrikerLag : Photon.MonoBehaviour {


	public Vector3 realPos;

	void Update () {
		if(!photonView.isMine){
			transform.position = Vector3.Lerp(transform.position,realPos,.5f);
		}
	}
	
	
	
	
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			
		}
		else
		{
			//transform.position = (Vector3)stream.ReceiveNext();
			//transform.rotation = (Quaternion)stream.ReceiveNext();
			
			realPos = (Vector3)stream.ReceiveNext();
		}
	}
}
