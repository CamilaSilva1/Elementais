//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//Sair de uma sala online
//linguagem utilizada: C# com Photon
//ferramenta: Unity 

//bibliotecas
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deixar sala
public class LeaveRoomMenu : MonoBehaviour
{
	[SerializeField]
    private RoomsCanvases _roomCanvas;

	//inicializar salas com canvas
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanvas = canvases;
    }

	//deixar sala online 
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        //_roomCanvas.CurrentRoomCanvas.Hide();
    }
}
