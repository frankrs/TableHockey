using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Player player;
	public ScoreBoard scoreBoard;
	public GameSounds gameSounds;
	public Transform puck;


	public IEnumerator Score(Player p){
		if(p == Player.player1){
			scoreBoard.p1score++;
		}
		if(p == Player.player2){
			scoreBoard.p2Score++;
		}
		//yield return null;
		audio.clip = gameSounds.airHorn;
		audio.Play();
		while(audio.isPlaying){
			yield return new WaitForEndOfFrame();
		}
		puck.position = new Vector3(0f,0f,0f);
		puck.rigidbody2D.velocity = new Vector2(0f,0f);
	}

}

[System.Serializable]
public class ScoreBoard{
	public int p1score;
	public int p2Score;
	public int playTo;
}

[System.Serializable]
public enum Player{
	player1,
	player2
}

[System.Serializable]
public class GameSounds{
	public AudioClip airHorn;
}