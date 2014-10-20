using UnityEngine;
using System.Collections;

public class PuckSound : MonoBehaviour {

	public float impact;
	public AudioClip puckHitSound;
	
	void OnCollisionEnter2D(Collision2D col) {
		impact = col.relativeVelocity.magnitude;
		audio.PlayOneShot(puckHitSound,impact*.1f);
	}
	

}
