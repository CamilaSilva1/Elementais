//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//criar ou entrar em alguma sala online
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//criar ou entrar em alguma sala
public class createOrJoinRoomCanvas : MonoBehaviour
{
	[SerializeField]
    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    [SerializeField]
    private createListingsMenu _roomListingsMenu;

	//inicializando as salas de inicio no canvas 
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _createRoomMenu.FirstInitialize(canvases);
        _roomsCanvases = canvases;
        _roomListingsMenu.FirstInitialize(canvases);
    }

}
