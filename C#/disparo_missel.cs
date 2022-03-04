//Camila Silva
//Script desenvolvido para a ação de um míssel em um jogo
//Linguagem utilizada: C#
//ferramenta: unity

//Importando bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo_missel : MonoBehaviour
{
	//variaveis
   [SerializeField]
    private GameObject missil;
	[SerializeField]
    private GameObject copia_missil;

 
    // Update is called once per frame
    void Update()
    {
		//função criada para verificar se a tecla "space" está pressionada
		//Se sim, instanciar missil no jogo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            copia_missil = Instantiate(missil, transform.position, transform.rotation);

            // destrois missil após 5 seg
            Destroy(copia_missil, 5);
        }

    }
}