using UnityEngine;
using System.Collections;

public class PuckLag : Photon.MonoBehaviour {

	public Vector3 realPos;
	public Quaternion realRot;



//		void Update () {
//			if(!photonView.isMine){
//				transform.position = Vector3.Lerp(transform.position,realPos,.5f);
//			}
//		}







		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting)
		{

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(rigidbody2D.position);
			stream.SendNext(rigidbody2D.rotation);
			stream.SendNext(rigidbody2D.velocity);
			stream.SendNext(rigidbody2D.angularVelocity);
		}
		else
		{
			//realPos = (Vector3)stream.ReceiveNext();
			//realRot =  (Quaternion)stream.ReceiveNext();
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation =  (Quaternion)stream.ReceiveNext();

			rigidbody2D.position = (Vector2)stream.ReceiveNext();
			rigidbody2D.rotation = (float)stream.ReceiveNext();
			rigidbody2D.velocity = (Vector2)stream.ReceiveNext();
			rigidbody2D.angularVelocity = (float)stream.ReceiveNext();
		}
	}
}
