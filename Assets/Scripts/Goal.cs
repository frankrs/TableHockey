using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public GameManager gameManager;
	public Player player;

	void OnTriggerEnter2D (){
		gameManager.StartCoroutine("Score",player);
	}

}
