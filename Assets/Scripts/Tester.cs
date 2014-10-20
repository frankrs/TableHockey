using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Debug.Log(StaticShit.gameType);
		Debug.Log(StaticShit.thisPlayer);
	}

}
