//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//Customizando sala online randomica 
//linguagem utilizada: C# com Photon
//ferramenta: Unity 

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class RandomCustomGenerator : MonoBehaviour
{
    [SerializeField]
    private Text _text;

	[SerializeField]
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

	//função para setar numero randomico 
    private void SetCustomNumber()
    {
		//numero randomico 
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

		//recebendo numero randomico 
        _text.text = result.ToString();

        _myCustomProperties["RandomNumber"] = result;
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
        //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }

	//função para ativar o customNumber 
    public void OnClick_button()
    {
        SetCustomNumber();
    }
}
