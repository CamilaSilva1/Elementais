//script criado por Camila Silva para o card game elementais
//Responsavel pela seleção do XP de cada jogador


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class selectXP : MonoBehaviour
{
	//acessando a tabela no banco de dados
    string URL = "http://api.elementaisgame.com/ranking/SelectXP.php";//acessando banco de dados

    public string[] usersData;//array dos dados do banco 

	//rotina
    IEnumerator Start()
    {
        WWW Usuarios = new WWW(URL);
        yield return Usuarios;
        string usersDataString = Usuarios.text;//array dos dados em texto unico
        usersData = usersDataString.Split(';');
    }

}
