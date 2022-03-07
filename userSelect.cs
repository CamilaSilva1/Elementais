//script criado por Camila Silva para o card game elementais
//Responsavel para selecionar cada usuario cadastrado no banco de dados e spawnando eles no painel do ranking


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class userSelect : MonoBehaviour
{
	
	//acessando tabela no banco de dados
    string URL = "http://api.elementaisgame.com/ranking/Select.php";//acessando banco de dados
    

    public string[] usersData;//array dos dados do banco 

    //variaveis
	[SerializedField]
    private TextMeshProUGUI nomePadraoTXT, nomeOuroTXT, nomePrataTXT, nomeBronzeTXT;

	[SerializedField]
    private TextMeshProUGUI XPOuro, XPPrata, XPBronze, XPPadrao;

	[SerializedField]
    private TextMeshProUGUI rankOuroTXT, rankPrataTXT, rankBronzeTXT, rankPadraoTXT;

	[SerializedField]
    private GameObject canvas, painelPadrao;

	[SerializedField]
    private selectXP select_xp;

	[SerializedField]
    private GameObject[] spawn;

    int i;


    //rotina para puxar todos os dados do banco em forma de ranking
    IEnumerator Start()
    {
        WWW Usuarios = new WWW(URL);
        yield return Usuarios;
        string usersDataString = Usuarios.text;//array dos dados em texto unico
        usersData = usersDataString.Split(';');

		//spawnando objeto com os dados do banco 
        spawn = new GameObject[usersData.Length];


        //laço de repetição para buscar todos os dados do banco 
        for (i = 0;  i <= usersData.Length; i++)
        {
           
            if (i >= usersData.Length)
            {
                painelPadrao.SetActive(false);
                Destroy(spawn[3]);
            }

            else if (i.Equals(0))
            {
                nomeOuroTXT.text =  usersData[i];
                rankOuroTXT.text = "" + (i + 1);
                XPOuro.text = select_xp.usersData[i];
            }

            else if (i.Equals(1)){

                nomePrataTXT.text = usersData[i];
                rankPrataTXT.text = ""  + (i + 1);
                XPPrata.text = select_xp.usersData[i];
            }

            else if (i.Equals(2))
            {
                nomeBronzeTXT.text = usersData[i];
                rankBronzeTXT.text = "" + (i + 1);
                XPBronze.text = select_xp.usersData[i];
            }


            else
            {
                

                //instanciar um text para mostrar as classificações de cada jogador
				//dentro de uma grid
                spawn[i] = Instantiate(painelPadrao);

                nomePadraoTXT.text =  usersData[i];
                rankPadraoTXT.text = ""  + (i + 1);
                XPPadrao.text = select_xp.usersData[i];

                spawn[i].transform.parent = canvas.transform;
                

                spawn[i].GetComponent<RectTransform>().sizeDelta = painelPadrao.GetComponent<RectTransform>().sizeDelta;
                spawn[i].GetComponent<RectTransform>().localScale = painelPadrao.GetComponent<RectTransform>().localScale;
                spawn[i].GetComponent<RectTransform>().position = painelPadrao.GetComponent<RectTransform>().position;

            }


        }

    }


}
