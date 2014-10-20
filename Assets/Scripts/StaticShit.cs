using UnityEngine;
using System.Collections;

public static class StaticShit {
	public static GameType gameType;
	public static ThisPlayer thisPlayer;
}




public enum GameType{
	OnePlayer,
	TwoPlayers,
	Online
}


public enum ThisPlayer{
	p1,
	p2
}