//Camila Silva
//Script desenvolvido para o movivento do missil em um jogo
//linguagem utilizada: C#
//ferramenta: unity

//bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimenta_missel : MonoBehaviour {

	//variaveis
	[SerializeField]
    private float velocidade;
	[SerializeField]
    private GameObject explosao;

	//atribuindo uma velocidade inicial
	// Use this for initialization
	void Start () {
        velocidade = 50;
	}
	
	//aplicando velocidade ao missil 
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, velocidade * Time.deltaTime);
        
	}
	
	//função para verificar se o missil colidiu com outro objeto no jogo 
    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "Nave")
        {
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
