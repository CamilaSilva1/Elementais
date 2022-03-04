//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//criação das salas online
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

//criar menu da sala
public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    
	[SerializeField]
    private Text _roomName;

	[SerializeField]
    private RoomsCanvases _roomsCanvases;

	//função para a inicialização 
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    //criando sala online 
    public void OnClick_CreateRoom()
    {
		//verificando se possui conexão 
        if (!PhotonNetwork.IsConnected)
            return;

		//opções de salas disponiveis no momento e o limite de players
        RoomOptions options = new RoomOptions();
        //options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = 2;
        options.PublishUserId = true;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, null);
    }

    //sala criada
    public override void OnCreatedRoom()
    {
        Debug.Log("Sala criada com sucesso", this);
        //_roomsCanvases.CurrentRoomCanvas.Show();
    }

    //sala nao criada
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Falha ao criar a sala" + message, this);
    }
}
