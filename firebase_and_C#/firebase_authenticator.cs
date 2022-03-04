//Camila Silva
//Script desenvolvido para a autenticação de login de um game mobile 
//linguagem utilizada: C#, php e mysql com firebase
//ferramenta: unity 

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;


public class firebase_authenticator : MonoBehaviour
{
	[SerializeField]
    private static firebase_authenticator instance;
	[SerializeField]
    private DependencyStatus dependencyStatus;
	[SerializeField]
    private FirebaseAuth auth;
	[SerializeField]
    private FirebaseUser User;


    private void Awake()
    {
		//instanciar objeto
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

		//inicializar firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if(dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Nao resolveu" + dependencyStatus);
            }

        });
    }

	//autenticando firebase
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }
}
