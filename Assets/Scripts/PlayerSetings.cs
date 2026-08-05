// create by: Vitor Gabriel
// date: 05/08/2026 as 13:20

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetings : MonoBehaviour
{
    [Header("Atributos do Player")]
    public float velocidade = 5f; // velocidade
    public float dano = 3f; // dano

    [Header("Sprites do Player")]
    public PlayerAnimationController playerAnim; // coloca aonde esta script

    // enum guarda valores igual uma lista, so que diferente de vetores que guarda numeros, ele guarda nomes.
    public enum Direcao // Enum com todas as direções
    {
        Baixo,
        Cima,
        Esquerda,
        Direita
    }
    public Direcao direcaoAtual = Direcao.Baixo; //variavel que vai indicar qual a direcao atual


    void Update()
    { 
        if (Input.GetAxisRaw("Horizontal") == -1) // caso usar A colocar script andando para esquerda
        {
            transform.position -= transform.right * (Time.deltaTime * velocidade);
            direcaoAtual = Direcao.Esquerda;
            playerAnim.PlayAnimation("ThePurpleKingWalkLeftAnimation");
        }

        if (Input.GetAxisRaw("Horizontal") == 1) // caso usar D colocar script andando para direita
        {
            transform.position += transform.right * (Time.deltaTime * velocidade);
            direcaoAtual = Direcao.Direita;
            playerAnim.PlayAnimation("ThePurpleKingWalkRightAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position -= transform.up * (Time.deltaTime * velocidade); // caso use o S colocar o script andando para baixo
            direcaoAtual = Direcao.Baixo;
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += transform.up * (Time.deltaTime * velocidade); // caso apertar W colocar a sprite de costas
            direcaoAtual = Direcao.Cima;
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimationBack_");
        }

        if (Input.GetMouseButton(0)) 
        {
            switch (direcaoAtual) 
            {
                case Direcao.Direita:

                    break;

                case Direcao.Esquerda:

                    break;

                case Direcao.Cima:
                    playerAnim.PlayAnimation("AtacckAnimationBack");
                    break;

                case Direcao.Baixo:
                    playerAnim.PlayAnimation("AtacckAnimationFront");
                    break;
            }
        }
    }
}