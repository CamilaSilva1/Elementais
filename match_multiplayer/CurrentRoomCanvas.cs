//Camila Silva 
//Script desenvolvido para o match multiplayer de um game mobile 
//linguagem utilizada: C#
//Ferramenta: Unity 

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
	
	//variaveis 
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;
	[SerializeField]
    public LeaveRoomMenu LeaveRoomMenu { get { return _leaveRoomMenu; } }

	[SerializeField]
    private RoomsCanvases _roomsCanvases;

	//função para realizar o primeiro inicializador dentro do jogo com canvas
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    /**public void Show()
    {
        gameObject.SetActive(true);
    }*/

    /**public void Hide()
    {
        gameObject.SetActive(false);
    }*/
}
