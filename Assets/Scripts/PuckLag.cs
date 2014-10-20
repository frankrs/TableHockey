using UnityEngine;
using System.Collections;

public class PuckLag : Photon.MonoBehaviour {
	
	Vector2 realPosition = Vector2.zero;
	Quaternion realRotation = Quaternion.identity;

	Vector2 realPositionP = Vector2.zero;
	float realRotationP = 0f;
	Vector2 realVelocityP = Vector2.zero;
	float realAVelocityP = 0f;

	public float speed = 50f;


	void Update () {
		if(!photonView.isMine){
			transform.position = Vector3.Lerp(transform.position, realPosition, speed*Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, speed*Time.deltaTime);

//			transform.position = realPosition;
//			transform.rotation = realRotation;
		}
	}


	void FixedUpdate () {
		if(!photonView.isMine){
//			rigidbody2D.position = Vector2.Lerp(rigidbody2D.position, realPositionP, speed*Time.deltaTime);
//			rigidbody2D.rotation = Mathf.Lerp(rigidbody2D.rotation, realRotationP, speed*Time.deltaTime);
//			rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, realVelocityP, speed*Time.deltaTime);
//			rigidbody2D.angularVelocity = Mathf.Lerp(rigidbody2D.angularVelocity, realAVelocityP, speed*Time.deltaTime);

			rigidbody2D.position = realPositionP;
			rigidbody2D.rotation = realRotationP;
			rigidbody2D.velocity = realVelocityP;
			rigidbody2D.angularVelocity = realAVelocityP;
			
			
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
