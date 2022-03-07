//Camila Silva
//Script desenvolvido para realizar o login de um game mobile
//Linguagem utilizada: C#, php e mysql com firebase
//ferramenta: unity 

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;

public class loginAuth : MonoBehaviour
{
	//variaveis de recebimento
	[SerializeField]
    private TMP_InputField emailField;
	[SerializeField]
    private TMP_InputField senhaField;
	[SerializeField]
    private TMP_Text erroLoginText;
	[SerializeField]
    private TMP_Text sucessoLoginText;

 

 //função para chamar rotina de login
    public void LoginButton()
    {
        StartCoroutine(StartLogin(emailField.text, senhaField.text));
    }

	
	//rotina para realizar o login com firebase
    private IEnumerator StartLogin(string email, string senha)
    {
		//tarefa de recebimento do email e senha 
        var loginTesk = firebase_authenticator.instance.auth.SignInWithEmailAndPasswordAsync(email, senha);
		//recebendo uma resposta do login
        yield return new WaitUntil(predicate: () => loginTesk.IsCompleted);

		//verificação
			if(loginTesk.Exception != null)
			{
				HandleLoginErrors(loginTesk.Exception);
			}
			else
			{
				LoginUser(loginTesk);
			}
    }

	//se caso ocorrer algum erro com a autenticação do login 
    void HandleLoginErrors(System.AggregateException loginException)
    {
        Debug.LogWarning(message: $"Falhou {loginException}");
        FirebaseException firebaseEx = loginException.GetBaseException() as FirebaseException;
        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

        erroLoginText.text = DefineLoginErrorMessage(errorCode);
    }

	//função para definir uma mensagem para possiveis erros 
    string DefineLoginErrorMessage(AuthError errorCode)
    {
        switch (errorCode)
        {
            case AuthError.MissingEmail:
                return "faltando email";

            case AuthError.MissingPassword:
                return "Faltando senha";

            case AuthError.InvalidEmail:
                return "email invalido";

            case AuthError.UserNotFound:
                return "conta nao encontrada";

            default:
                return "login falhou";
        }
    }

	//função para o login feito com sucerro
    void LoginUser(System.Threading.Tasks.Task<Firebase.Auth.FirebaseUser> loginTask)
    {
		//recebendo usuario e autenticando
        firebase_authenticator.instance.User = loginTask.Result;
        Debug.LogFormat("Usuario cadastrado com sucesso: {0} ({1})", firebase_authenticator.instance.User.DisplayName, firebase_authenticator.instance.User.Email);

        erroLoginText.text = "";
        sucessoLoginText.text = "logado";
    }

}
