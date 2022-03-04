//Camila Silva
//Script desenvolvido para gerenciar o cadastro online em um jogo 
//linguagem utilizada: C# e php
//ferramenta: unity


//bibliotecas
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Globalization;

public class Web : MonoBehaviour
{

	//função para realizar o cadastro utilizando arquivos externos de PHP
	
    #region cadastro
    public async Task<String> CadastroForm(string nome, string email, string nickname, string senha)
    {
        string retorno = null;
        try
        {
			//acessando banco de dados 
            string uri = "https://elementaisgame.com/api/v1api/game/cadastro_Form.php";
            WWWForm form = new WWWForm();
            form.AddField("nome", nome);
            form.AddField("email", email);
            form.AddField("nickname", nickname);
            form.AddField("senha", senha);
            form.AddField("auth", 0);

			//request do banco de dados
            UnityWebRequest www = UnityWebRequest.Post(uri, form);
            await www.SendWebRequest();

			//se ocorrer algum erro
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                retorno = null;
            }
            else
            {
				//se nao ocorrer erro
                if (www.isDone)
                {
                    Debug.Log(":\nReceived: " + www.downloadHandler.text);
                    retorno = www.downloadHandler.text;
                }
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log("\nException Caught!");
            Debug.Log("Erro: " + e.Message);
        }
        return retorno;
    }

	//sem acessar a senha 
    public async Task<String> cadastrarFG(string nome, string email, string nickname)
    {
        string retorno = null;
        try
        {
            string uri = "https://elementaisgame.com/api/v1api/game/cadastro_FG.php";
            WWWForm form = new WWWForm();
            form.AddField("nome", nome);
            form.AddField("email", email);
            form.AddField("nickname", nickname);

            UnityWebRequest www = UnityWebRequest.Post(uri, form);
            await www.SendWebRequest();

			//se ocorrer algum erro
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("http error: " + www.error);
                return null;
            }
            else
            {
				//se nao ocorrer erro
                if (www.isDone)
                {
                    Debug.Log(":\nReceived: " + www.downloadHandler.text);
                    retorno = www.downloadHandler.text;
                }
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log("\nException Caught!");
            Debug.Log("Erro: " + e.Message);
        }
        return retorno;
    }
    #endregion

	//função para gerenciar o login com autenticação
    #region Login
    public async Task<string> LoginFG(string email, string auth)
    {
        string result = null;
        try
        {
			//acessando scripts externos de php
            string uri = "https://elementaisgame.com/api/v1api/game/loginFG.php";
            WWWForm form = new WWWForm();
            form.AddField("email", email);
            form.AddField("auth", auth);

            UnityWebRequest www = UnityWebRequest.Post(uri, form);

			//mandando um request
            await www.SendWebRequest();
			//se ocorrer algum erro ou nao 
            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
            {
                result = www.downloadHandler.text;
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log("erro: \n" + e.Message);

        }

        return result;
    }

	//função para gerenciar o login sem autenticação
    public async Task<string> LoginForm(string email, string senha)
    {
        string result = null;
        try
        {
            string uri = "https://elementaisgame.com/api/v1api/game/loginForm.php";
            WWWForm form = new WWWForm();
            form.AddField("email", email);
            form.AddField("senha", senha);
            form.AddField("auth", 0);

            UnityWebRequest www = UnityWebRequest.Post(uri, form);

            await www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Main.Instance.ShowError(www.error);
            }
            else
            {
                result = www.downloadHandler.text;
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log("erro: \n" + e.Message);
            Main.Instance.ShowError(e.Message);

        }

        return result;
    }
    #endregion
}

