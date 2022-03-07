//script criado por Camila Silva para o card game elementais
//Responsavel pela seleção de jogadores de acordo com sua classificação

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class selecPlacar : MonoBehaviour
{
	//variaveis
	
	//acessando banco de dados 
    string URL = "http://api.elementaisgame.com/ranking/SelectVitoria.php";//acessando banco de dados

	[SerializedField]
    private string[] usersData;//array dos dados do banco 

	[SerializedField]
    private TextMeshProUGUI nometextOuro, nomeTextPrata, nomeTextbronze;

	[SerializedField]
    private TextMeshProUGUI textPartida;

	[SerializedField]
    private userSelect UserSelect;

	[SerializedField]
    private GameObject brasaoOuro, brasaoPrata, brasaoBronze, brasaoPadrao;

	//rotina de conexão
    IEnumerator Start()
    {
        WWW Usuarios = new WWW(URL);
        yield return Usuarios;
        string usersDataString = Usuarios.text;//array dos dados em texto unico
        usersData = usersDataString.Split(';');

    }

	//selecionando jogadores com classificação Ouro
    public void selecPlacarOuro()
    {
        for (int i = 0; i <= UserSelect.usersData.Length; i++)
        {
            if (nometextOuro.text.Equals(UserSelect.usersData[i]))
            {
                textPartida.text = usersData[i];

                brasaoOuro.SetActive(true);

                if (brasaoPrata.activeSelf)
                {
                    brasaoPrata.SetActive(false);
                }

                if (brasaoBronze.activeSelf)
                {
                    brasaoBronze.SetActive(false);
                }
                if (brasaoPadrao.activeSelf)
                {
                    brasaoPadrao.SetActive(false);
                }

            }
        }
    }

	//selecionando jogadores com classificação Prata
    public void selecPlacarPrata()
    {
        for (int i = 0; i <= UserSelect.usersData.Length; i++)
        {
            if (nomeTextPrata.text.Equals(UserSelect.usersData[i]))
            {
                textPartida.text = usersData[i];

                brasaoPrata.SetActive(true);

                if (brasaoOuro.activeSelf)
                {
                    brasaoOuro.SetActive(false);
                }

                if (brasaoBronze.activeSelf)
                {
                    brasaoBronze.SetActive(false);
                }
                if (brasaoPadrao.activeSelf)
                {
                    brasaoPadrao.SetActive(false);
                }
            }
        }
    }

	//selecionando jogadores com classificação Bronze
    public void selecPlacarBronze()
    {
        for (int i = 0; i <= UserSelect.usersData.Length; i++)
        {
            if (nomeTextbronze.text.Equals(UserSelect.usersData[i]))
            {
                textPartida.text = usersData[i];

                brasaoBronze.SetActive(true);

                if (brasaoOuro.activeSelf)
                {
                    brasaoOuro.SetActive(false);
                }

                if (brasaoPrata.activeSelf)
                {
                    brasaoPrata.SetActive(false);
                }
                if (brasaoPadrao.activeSelf)
                {
                    brasaoPadrao.SetActive(false);
                }
            }
        }
    }
}
