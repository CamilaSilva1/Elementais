//script criado por Camila Silva para o card game elementais
//Responsavel por ativar o painel do ranking dento do jogo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ativarRanking : MonoBehaviour
{
	[SerializedField]
    private GameObject painelRanking;
    

    // Start is called before the first frame update
    void Start()
    {
		//ativando painel
        painelRanking.SetActive(true);
    }


	//chamando scene
    public void guardiao()
    {
        SceneManager.LoadScene("ranking_elementos");
       
    }

	//chamando scene
    public void global()
    {
        SceneManager.LoadScene("ranking_final");
        
    }

}
