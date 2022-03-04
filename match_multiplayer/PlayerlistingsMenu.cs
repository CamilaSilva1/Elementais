//Camila Silva
//Script desenvolvido para o match multiplayer de um game mobile
//gerenciador do script PlayerListings
//linguagem utilizada: C# com Photon
//ferramenta: Unity 


//bibliotecas
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerlistingsMenu : MonoBehaviourPunCallbacks
{
	//variaveis
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListings _playerListing;
    [SerializeField]
    private Text _readyUpText;

    private List<PlayerListings> _listings = new List<PlayerListings>();
    private RoomsCanvases _roomsCanvases;
    private bool _ready = false;

	//ativando e recebendo sala dos jogadores 
    public override void OnEnable()
    {
        base.OnEnable();
        //SetReadyUp(false);
        GetCurrentRoomPlayers();
    }

	//desativando e limpando players 
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listings.Count; i++)
            Destroy(_listings[i].gameObject);

        _listings.Clear();
    }

	//inicializando 
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    /**private void SetReadyUp(bool state)
    {
        _ready = state;
        if (_ready)
            _readyUpText.text = "R";
        else
            _readyUpText.text = "N";
    }*/

	//função para obter atuais jogadores nas salas online
    private void GetCurrentRoomPlayers()
    {
		//vericando conexão 
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

	//adicionando lista de jogadores 
    private void AddPlayerListing(Player player)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].SetPlayerInfo(player);
        }
        else
        {
			//instanciando lista de jogadores e setando informações 
            PlayerListings listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listings.Add(listing);
            }
        }
    }

	//função para deixar sala 
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }

	//função para verificar a entrada de jogadores 
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

	//função para a verificação de quando o jogador deixar a sala 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

	//startando as salas com photon 
    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //for (int i = 0; i < _listings.Count; i++)
            //{
            //    if (_listings[i].Player != PhotonNetwork.LocalPlayer)
            //    {
            //        if (!_listings[i].Ready)
            //            return;
            //    }
            //}

            //PhotonNetwork.CurrentRoom.IsOpen = false;
            //PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }

	//função para dar pronto com os jogadores na sala online 
    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            //SetReadyUp(!_ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
        }
    }

    /**[PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
            _listings[index].Ready = ready;
    }*/
}
