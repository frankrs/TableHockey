using UnityEngine;
using System.Collections;
using Photon;


[ExecuteInEditMode]
public class TitleScreenSetup : Photon.MonoBehaviour {


	public NetShit netShit;
	public GuiShit guiShit;



	void Update () {
		// update net shit
		netShit.state = PhotonNetwork.connectionState;
		netShit.inRoom = PhotonNetwork.inRoom;

		// adust font styles for screen size
		guiShit.hw = new Vector2(Screen.height,Screen.width);
		guiShit.styles.button.fontSize = Mathf.RoundToInt(guiShit.hw.y/guiShit.sizeAdjust);
		guiShit.styles.box.fontSize = Mathf.RoundToInt(guiShit.hw.y/guiShit.sizeAdjust);
	}

	void OnGUI (){
		GUILayout.BeginArea(new Rect(guiShit.hw.y*.1f,guiShit.hw.x*.1f,guiShit.hw.y*.8f,guiShit.hw.x*.8f));


		// the start page
		if(guiShit.page == Page.start){
			GUILayout.Box("AirHockey",guiShit.styles.box);
			if(GUILayout.Button("OnePlayer",guiShit.styles.button)){
				PhotonNetwork.offlineMode = true;
				StaticShit.gameType = GameType.OnePlayer;
				StaticShit.thisPlayer = ThisPlayer.p1;
				PhotonNetwork.CreateRoom("offline");
				PhotonNetwork.LoadLevel(1);
				}
			if(GUILayout.Button("TwoPlayer",guiShit.styles.button)){
				PhotonNetwork.offlineMode = true;
				StaticShit.gameType = GameType.TwoPlayers;
				StaticShit.thisPlayer = ThisPlayer.p2;
				PhotonNetwork.CreateRoom("offline");
				PhotonNetwork.LoadLevel(1);
				}
			if(GUILayout.Button("PlayOnline",guiShit.styles.button)){
				guiShit.page = Page.connect;
				}
			if(GUILayout.Button("Options",guiShit.styles.button)){
				
				}
			if(GUILayout.Button("HowToPlay",guiShit.styles.button)){
				
				}
			}

		if(guiShit.page == Page.connect){

			if(netShit.state != ConnectionState.Connected){
				GUILayout.Box(netShit.state.ToString(),guiShit.styles.box);
				if(GUILayout.Button("Connect",guiShit.styles.button)){
					PhotonNetwork.offlineMode = false;
					PhotonNetwork.sendRate = 100;
					PhotonNetwork.sendRateOnSerialize = 100;
					Connect();
					}
			}

//			else if (netShit.inRoom == false){
//				GUILayout.Box("JoinGame",guiShit.styles.box);
//				if(GUILayout.Button("Random",guiShit.styles.button)){
//					RandomRoom();
//				}
//			}

			else{
				if(GUILayout.Button("LetsPlay",guiShit.styles.button)){

					PhotonNetwork.LoadLevel(1);
				}
			}


		}

		// the lobby page
		if(guiShit.page == Page.lobby){
			if(GUILayout.Button("JoinRandom",guiShit.styles.button)){

			}
			if(GUILayout.Button("TwoPlayer",guiShit.styles.button)){

			}
			if(GUILayout.Button("PlayOnline",guiShit.styles.button)){

			}

		}




		GUILayout.EndArea();
		}







	void Connect(){
		//startPageState = StartPageState.connecting;
		PhotonNetwork.ConnectUsingSettings("1.0");
	}
	

	void RandomRoom (){
		PhotonNetwork.JoinOrCreateRoom("Random",null,null);
	}


	void OnJoinedRoom (){
		if(PhotonNetwork.isMasterClient){
			StaticShit.thisPlayer = ThisPlayer.p1;
		}
		else{
			StaticShit.thisPlayer = ThisPlayer.p2;
		}
	}


	void OnConnectedToPhoton(){
		Debug.Log("connected");
	}

}


[System.Serializable]
public class NetShit{
	public ConnectionState state;
	public bool inRoom;
}

[System.Serializable]
public class Styles{
	public GUIStyle box;
	public GUIStyle button;
}

[System.Serializable]
public class GuiShit{
	public Styles styles;
	public Page page;
	public Vector2 hw;
	public int sizeAdjust;
}

[System.Serializable]
public enum Page{
	start,
	lobby,
	connect,
	options
}