using System;
using UnityEngine;

public class FaseSetting : MonoBehaviour
{
    //variaveis 
    public static FaseSetting instance;

    public int inimigosVivos;

    public bool podePintar = false;
    public int blocosPintados = 0;

    public bool faseConcluida = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inimigosVivos = GameObject.FindGameObjectsWithTag("Inimigos").Length; // conta quantos inimigos estao vivos

        Debug.Log("Inimigos Vivos:"+ inimigosVivos);

        if(inimigosVivos <= 0)
        {
            podePintar = true; // caso inicie com inimigos zerados pode pintar
        }   
    }

    public void InimigoMorreu() 
    {
        inimigosVivos--;

        Debug.Log("Inimigos Vivos:" + inimigosVivos);

        if (inimigosVivos <= 0) 
        {
            podePintar = true; // caso todos os inimigos morram, vai permitir que o player pinte
        }
    }

    public void ContarBlocos() 
    {
        blocosPintados++;

        Debug.Log("Blocos Pintados:" + blocosPintados);

        if (blocosPintados >= 140)
        {
            Debug.Log("Fase Concluida!");
            faseConcluida = true;
        }
    }

    public void TirarBlocos() 
    {
        if(blocosPintados > 0) 
        { 
            blocosPintados--;
        } 
        else if(blocosPintados < 0) 
        {
            blocosPintados = 0;
            Debug.Log("ZERADO");
        }
        Debug.Log("Blocos Pintados:" + blocosPintados);
    }
}
