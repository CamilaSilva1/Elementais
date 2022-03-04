//Camila Silva
//Script para o salvamento de imagens em um jogo
//linguagem utilizada C#
//ferramenta: unity


//importando bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ImageManager : MonoBehaviour
{
    public static ImageManager instance;

    string _basePath;
    //TODO:
    //0. Make a base path
    //1. check if image already exists
    //2. save images
    //3. load images(io)
	
	//função para criar um caminho base (diretorio)
    void Start()
    {
        if (instance != null) 
        {
            GameObject.Destroy(this);
            return;
        }
        instance = this;

        _basePath = Application.persistentDataPath + "/Images/";
        if (!Directory.Exists(_basePath)) 
        {
            Directory.CreateDirectory(_basePath);
        }
    }

	//verificando se as imagens ja existem
    bool ImageExists(string name) 
    {
        return File.Exists(_basePath + name);
    }

	//salvando imagens
    public void SaveImage(string name, byte[] bytes) 
    {
        File.WriteAllBytes(_basePath + name, bytes);
    }

	//carregando imagens
    public byte[] LoadImages(string name) 
    {
        byte[] bytes = new byte[0];
        if(ImageExists(name))
            bytes =  File.ReadAllBytes(_basePath + name);
        return bytes;
    }
	
	//mostrando imagens dentro do jogo 
    public Sprite BytesToSprite(byte[] bytes) 
    {
        //criar texture2D
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        //criar sprite 
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
