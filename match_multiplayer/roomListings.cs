//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//listar salas online 
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class roomListings : MonoBehaviour
{
    [SerializeField]
    private Text _text;

	[SerializeField]
    private RoomInfo RoomInfo { get; private set; }

	//função para setar as informações das salas (maximo de jogadores)
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

	//função para entrar na sala com o nome 
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
