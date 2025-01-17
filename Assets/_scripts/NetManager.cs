﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour {

    public const string VERSION = "1.0";
    public byte maxPlayers = 12;
    public GameObject avatarPrefab;
	private string roomNameServer;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(VERSION);
		var temp = PhotonVoiceNetwork.Client;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // below, we implement some callbacks of PUN
    // you can find PUN's callbacks in the class PunBehaviour or in enum PhotonNetworkingMessage


    public virtual void OnConnectedToMaster()
    {
        //Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        //PhotonNetwork.JoinRandomRoom();
		Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinOrCreateRoom();");
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.isVisible = true;
		roomOptions.MaxPlayers = maxPlayers;

		//PhotonNetwork.JoinLobby ();
		PhotonNetwork.JoinOrCreateRoom ("TestName", roomOptions, TypedLobby.Default);
    }

    public virtual void OnJoinedLobby()
    {
		foreach (RoomInfo game in PhotonNetwork.GetRoomList()) {
			Debug.Log (game.name);
			Debug.Log (game.PlayerCount);
			Debug.Log (game.MaxPlayers);
		}
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        //PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {

        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        GameObject obj = PhotonNetwork.Instantiate (avatarPrefab.name, Vector3.zero, Quaternion.identity, 0);
		//PhotonNetwork.GetRoomList

    }

	public void setRoomName(string newName) {
		roomNameServer = newName;
	}

	public string getRoomName() {
		return roomNameServer;
	}
}
