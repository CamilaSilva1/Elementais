//Camila Silva
//script para verificar o comportamento do inimigo em um jogo 
//linguagem utilizada: C#
//ferramenta: unity


//importando bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamento_inimigo : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		//movimento 
        transform.Translate(0, 0, 1 * Time.deltaTime);
		
	}

	//verificando se houve colisão com outro objeto no jogo
    void OnCollisionEnter(Collision colisao) {
        if (colisao.gameObject.tag == "missel") {
            print("ocorreu uma colisao com um missil");
            //Destroy(gameObject);
        }
    }
}
