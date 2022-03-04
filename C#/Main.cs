//Camila Silva
//Script desenvolvido para gerenciar algumas funçoes de um jogo mobile
//linguagem utilizada: C#
//ferramenta: unity


//importando bibliotecas
using Assets.arquivos.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
	//variaveis
	
    [HideInInspector]
    public static Main Instance;
    [HideInInspector]
    public GameObject UserProfile;
    [HideInInspector]
    public Web web;
    [HideInInspector]
    public AudioBase audioBase;
    [HideInInspector]
    public LoadingState ls;
    [HideInInspector]
    public AdMobManager ad;
    [HideInInspector]
    public config_usuario usuario;

    public Player player;
    //[HideInInspector]
    //public FacebookSetings facebook;
    [HideInInspector]
    public Inventory inventario;

	//acessar banco de dados
    private GerenciadorBancoLocal banco = new GerenciadorBancoLocal("databaseV2.db");

    public GameObject errorComponnent;
    public GameObject PrefabCarta;

	//vetor dos monstros do jogo 
    public List<Monstro> DeckInicial;

	//para gerenciar o banco de dados 
    public GerenciadorBancoLocal Banco { get => banco; set => banco = value; }

	//instanciar no começo do jogo 
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
		//chamando função 
        SetDefaults();
    }

	//carregar menu 
    #region Loadings
    public void MainMenu()
    {
        LoadingMenu();
        ls = LoadingState.MENU_INICIAL;
    }

	//carregar cena menu
    void LoadingMenu()
    {

        SceneManager.LoadScene(2);
    }
	//chamar tutorial 2
    public void Tutorial1Menu()
    {
        LoadingMenu();
        ls = LoadingState.TUTORIAL1;

    }

	//carregar tutorial 2
    public void Tutorial2Menu()
    {
        LoadingMenu();
        ls = LoadingState.TUTORIAL2;

    }
	
	//carregar treino
    public void Treino()
    {
        LoadingMenu();
        ls = LoadingState.TREINO;

    }
	
	//carregar multiplayer
    public void MultiplayerMenu()
    {
        LoadingMenu();
        ls = LoadingState.MULTIPLAYER;

    }
    #endregion

	//editar padrão 
	//função editar o login online, recebendo uma pagina da web 
    public void SetDefaults()
    {
		
        PlayerPrefs.SetString("VIDGIeventoAtual", null);
        web = GetComponent<Web>();
        web = GetComponent<Web>();
        audioBase = AudioBase._instance;
        ad = GetComponent<AdMobManager>();
        usuario = GetComponent<config_usuario>();
        //facebook = GetComponent<FacebookSetings>();
        inventario = GetComponent<Inventory>();
    }

	//função para mostrar erros possiveis 
    public void ShowError(string msg)
    {
        var ErrosEmTela = FindObjectsOfType<Erro_Tela>().Length;
        if (ErrosEmTela == 0)
        {
            errorComponnent.GetComponent<Erro_Tela>().MensagemErro(msg);
            Instantiate(errorComponnent, FindObjectOfType<Canvas>().transform);
        }
    }

	//função para parar todas as musicas do jogo
    public void StopAllMusics()
    {
        audioBase.stopMusicaMenu();
        audioBase.stopMusicaDerrota();
        audioBase.stopMusicaGameplay();
        audioBase.stopMusicaLobby();
        audioBase.stopMusicaTutorial();
        audioBase.stopMusicaVitoria();
        audioBase.stopMusicaTelaBatalha();
    }
}
