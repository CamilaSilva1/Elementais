//Camila Silva
//Script desenvolvinento para o adsense de um jogo mobile
//linguagem utilizada: C#
//ferramenta: unity


//importando bibliotecas
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

//script para a criação de Ads no Elementais, utilizando o Admob com o Unity 
public class AdMobManager : MonoBehaviour
{
	[SerializeField]
    private RewardedAd rewardedAd;//Video
	[SerializeField]
    private InterstitialAd InterstitialAd;//popUp
    //Referencia para o banner
	[SerializeField]
    private BannerView bannerView;
    //referencia para o video
    //private RewardBasedVideoAd rewardVideoAd;

    //ID do Aplicativo no Admob
    private string APP_ID = "ca-app-pub-3119375714600951~1420686511";
    string bannerTestId = "ca-app-pub-3940256099942544/6300978111";
    string videoTestId = "ca-app-pub-3940256099942544/5224354917";

    //// criar instancia
    // public static AdMobManager instance;

   
    void Start()
    {
        //inicializar o ID do aplicativo criado no Admob
        MobileAds.Initialize(initStatus => { });
        bannerPopUp();//inicializar o banner
        Video();//inicializar o video
    }

    //função para chamar o banner
    public void RequestBanner()
    {
        //Id do banner criado no Admob
         string banner_ID = "ca-app-pub-3119375714600951/6401835867";
        //Id do banner para teste
        //string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        //Criar um banner de 320x50 no topo da tela

        AdSize adSize = new AdSize(300,50);
        bannerView = new BannerView(banner_ID, adSize, AdPosition.Bottom);

        // Chamado quando uma solicitação de anúncio é carregada com sucesso.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Chamado quando uma solicitação de anúncio falhou ao carregar.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Chamado quando um anúncio é clicado.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Chamado quando o usuário retornou do aplicativo após um clique no anúncio.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Chamado quando o clique no anúncio fez com que o usuário saísse do aplicativo
        //this.bannerView.On += this.HandleOnAdLeavingApplication;
        //Para o real 
         AdRequest adRequest = new AdRequest.Builder().Build();
        //Para teste
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();
        //carregar o banner
        bannerView.LoadAd(adRequest);
    }
    private void HandleRewardBasedVideoLoaded(object sender, EventArgs e)
    {

    }

    //função para mostrar o banner de ad na tela
    public void Display_banner()
    {
        bannerView.Show();
    }

	//função para mostrar o video de ad na tela
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        //display_Video();
    }

	//função para mostrar um tipo de ad na tela
    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

	//função para mostrar um tipo de ad na tela
    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

	//função para mostrar um tipo de ad na tela
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

	//função para mostrar um tipo de ad na tela
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {

        Display_InterstitialAD();//mostrar o banner quando o video fechar
    }

	//função para verificar o ad na tela
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    //função para mostrar o video
    public void display_Video()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    //mostrar o banner popUp
    public void Display_InterstitialAD()
    {
        if (InterstitialAd.IsLoaded())
        {//Se o video for carregado
            InterstitialAd.Show();
        }
    }

    //Função para chamar o video
    public void Video()
    {

        string adUnitId;
#if UNITY_ANDROID
         adUnitId = "ca-app-pub-3119375714600951/3562200904";//id do video
       // adUnitId = "ca-app-pub-3940256099942544/5224354917";//id para teste
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif


        this.rewardedAd = new RewardedAd(adUnitId);

        // Chamado quando uma solicitação de anúncio é carregada com sucesso.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Chamado quando uma solicitação de anúncio falhou ao carregar.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToLoad;
        // Chamado quando um anúncio é exibido.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Chamado quando uma solicitação de anúncio não foi exibida.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Chamado quando o usuário deve ser recompensado por interagir com o anúncio.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Chamado quando o anúncio é fechado.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Crie uma solicitação de anúncio vazia.
        AdRequest request = new AdRequest.Builder().Build();
        // Carregue o anúncio premiado com a solicitação.
        this.rewardedAd.LoadAd(request);
    }

    //função para chamar o banner PopUp
    public void bannerPopUp()
    {
        //Id do video criado no Admob
        string interstitial_ID = "ca-app-pub-3119375714600951/8239812511";//id do banner popup
        //string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";//id do banner popup para teste

        InterstitialAd = new InterstitialAd(interstitial_ID);

        //Para o real 
        AdRequest adRequest = new AdRequest.Builder().Build();

        //Para teste
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        //carregar video 
        InterstitialAd.LoadAd(adRequest);

    }

    //Handle events
    //função para quando carregar 
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_banner();
    }
    //função para quando falhar o carregamento 
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }
    //Ad foi aberto
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
    //ad foi fechado
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
    //Ad deixou a aplicação
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    //Função que destroi o banner da tela
    public void DestroyBanner(){
        bannerView.Destroy();
    }
}
