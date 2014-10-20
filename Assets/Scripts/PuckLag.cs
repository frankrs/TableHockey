using UnityEngine;
using System.Collections;

public class PuckLag : Photon.MonoBehaviour {

	public Vector3 realPos;
	public Quaternion realRot;


	public Vector2 realPosition = Vector2.zero;
	public Quaternion realRotation = Quaternion.identity;

	public Vector2 realPositionP = Vector2.zero;
	public float realRotationP = 0f;
	public Vector2 realVelocityP = Vector2.zero;
	public float realAVelocityP = 0f;


	void Update () {
		if(!photonView.isMine){
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.5f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.5f);
		}
	}

	void FixedUpdate () {
		if(!photonView.isMine){
			rigidbody2D.position = Vector2.Lerp(rigidbody2D.position, realPositionP, 0.5f);
			rigidbody2D.rotation = Mathf.Lerp(rigidbody2D.rotation, realRotationP, 0.5f);
			rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, realVelocityP, 0.5f);
			rigidbody2D.angularVelocity = Mathf.Lerp(rigidbody2D.angularVelocity, realAVelocityP, 0.5f);
		}
	}
	
	
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
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();

			realPositionP = (Vector2)stream.ReceiveNext();
			realRotationP = (float)stream.ReceiveNext();
			realVelocityP = (Vector2)stream.ReceiveNext();
			realAVelocityP = (float)stream.ReceiveNext();
		}
	}
}
