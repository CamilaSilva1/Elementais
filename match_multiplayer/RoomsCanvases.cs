//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//salas online 
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private createOrJoinRoomCanvas _createOrJoinRoomCanvas;

	[SerializeField]
    private createOrJoinRoomCanvas CreateOrJoinRoomCanvas { get { return _createOrJoinRoomCanvas; } }


    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;

	[SerializeField]
    private  CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas; } }

	//chamando primeira inicialização 
    private void Awake()
    {
        FirstInicialize();
    }  

	//realizando a inicialização 
    private void FirstInicialize()
    {
        CreateOrJoinRoomCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);        
    }
}
