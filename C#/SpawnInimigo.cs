//Camila Silva
//Script realizado para o desenvolvimento de spawn em um jogo 
//linguagem utilizada: C#
//ferramenta: unity

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour {

	//variaveis
	[serializeField]
    private GameObject inimigo;
	
	[serializeField]
    private Vector3 posicaoRespawn;
	
	[serializeField]
    private float tempo;
	
	[serializeField]
    private Quaternion rotacaoRespawn;

	// Use this for initialization
	void Start () {
        //Instantiate(inimigo,MovimentoNave.posicaoPlayer, MovimentoNave.rotacaoPlayer);
        rotacaoRespawn = new Quaternion(0, 90,0 , 1);
        tempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//atribuindo valores ao tempo, posição do spawn inimigo e posição da nave 
        tempo = tempo + Time.deltaTime;
        posicaoRespawn = MovimentoNave.posicaoPlayer;
        posicaoRespawn.z = posicaoRespawn.z + 15;

        if (tempo >= 3f) {
            posicaoRespawn.x = Random.Range(-23, 23);
      
			//realizando o spawn do inimigo
            Instantiate(inimigo, posicaoRespawn, rotacaoRespawn);
            print("Tempo:" + tempo);
            print("Instanciar Inimigo");
            tempo = 0;
        }


	}
}
