//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//receber informações do player 
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerListings : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

	[SerializeField]
    private Player Player { get; private set; }
    //public bool Ready = false;

	//função para setar informações do player 
    public void SetPlayerInfo(Player player)
    {
		//recebendo objeto player 
        Player = player;

		//recebendo nickname do jogador 
        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
            result = (int)player.CustomProperties["RandomNumber"];
        _text.text = result.ToString() + "oi, " + player.NickName;
    }

}
