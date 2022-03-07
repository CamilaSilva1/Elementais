//Camila Silva
//Script desenvolvido para o registro de usuarios
//Linguagem utilizada: PHP
//ferramenta: unity 

//Bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class registerUser : MonoBehaviour
{
	//variaveis para guardar email e senha 
    public TMP_InputField inputEmail;
    public TMP_InputField inputSenha;

	//variavel botão
    public Button loginBtn;

	//chamar rotina Register
   public void callRegister()
    {
        StartCoroutine(Register());
    }
	
	//Rotina para realizar o registro de usuarios 
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", inputEmail.text);//acessando o campo email
        form.AddField("password", inputSenha.text);//acessando o campo senha 

		//Registro usuario 
        WWW www = new WWW("http://localhost/registroUsuario/register.php", form);
        yield return www;

        if(www.text == "0")
        {
            Debug.Log("User created sucessfully");//Caso o usuario for criado com sucesso

        }
        else
        {
            Debug.Log("user not created" + www.text);//caso de algum erro no registro
        }
    }
}
