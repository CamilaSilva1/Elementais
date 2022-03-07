//script criado por Camila Silva para o card game elementais
//Responsavel pela seleção de jogadores sem classificação

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class selecionarPlacarPadrao : MonoBehaviour
{
	//variaveis
    string URL = "http://api.elementaisgame.com/ranking/SelectVitoria.php";//acessando banco de dados

	[SerializedField]
    private string[] usersData;//array dos dados do banco 

	[SerializedField]
    private TextMeshProUGUI nometextpadrao;

	[SerializedField]
    private userSelect UserSelect;

	[SerializedField]
    private TextMeshProUGUI textPartida;

	[SerializedField]
    private GameObject brasaoOuro, brasaoPrata, brasaoBronze, brasaoPadrao;

	//rotina
    IEnumerator Start()
    {
        WWW Usuarios = new WWW(URL);
        yield return Usuarios;
        string usersDataString = Usuarios.text;//array dos dados em texto unico
        usersData = usersDataString.Split(';');

    }

	//função para selecionar os jogadores sem classificação
    public void selecPlacarPadrao()
    {
        for (int i = 0; i <= UserSelect.usersData.Length; i++)
        {
            if (nometextpadrao.text.Equals(UserSelect.usersData[i]))
            {
                textPartida.text = usersData[i];

                brasaoPadrao.SetActive(true);

                if (brasaoOuro.activeSelf)
                {
                    brasaoOuro.SetActive(false);
                }

                if (brasaoBronze.activeSelf)
                {
                    brasaoBronze.SetActive(false);
                }
                if (brasaoPrata.activeSelf)
                {
                    brasaoPrata.SetActive(false);
                }
            }
        }
    }

}
