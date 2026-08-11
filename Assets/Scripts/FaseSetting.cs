using System;
using UnityEngine;

public class FaseSetting : MonoBehaviour
{
    //variaveis 
    public static FaseSetting instance;
    public int inimigosVivos;
    public bool podePintar = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inimigosVivos = GameObject.FindGameObjectsWithTag("Inimigos").Length; // conta quantos inimigos estao vivos

        Debug.Log("Inimigos Vivos:"+ inimigosVivos);
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
}
