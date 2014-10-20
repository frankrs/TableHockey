using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class SterchBackground : MonoBehaviour {
	
	void Update () {
		guiTexture.pixelInset = new Rect(0f,0f,Screen.width,Screen.height);
	}
}
