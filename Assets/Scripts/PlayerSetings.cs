// create by: Vitor Gabriel
// date: 05/08/2026 as 13:20
// update: 11/08/2026 as 09:05

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetings : MonoBehaviour
{
    [Header("Atributos do Player")]
    public float velocidade = 5f; // velocidade
    public bool estaVivo = true; // se esta vivo

    [Header("Sprites do Player")]
    public PlayerAnimationController playerAnim; // coloca aonde esta script

    [Header("Atributos de Ataque")]
    public float dano = 3f; // dano
    private bool atacando = false;

    // enum guarda valores igual uma lista, so que diferente de vetores que guarda numeros, ele guarda nomes.
    public enum Direcao // Enum com todas as direções
    {
        Baixo,
        Cima,
        Esquerda,
        Direita
    }
    public Direcao direcaoAtual = Direcao.Baixo; //variavel que vai indicar qual a direcao atual


    IEnumerator Atacar() 
    {
        atacando = true;

        switch (direcaoAtual)
        {
            case Direcao.Direita:
                playerAnim.PlayAnimation("AttackAnimationRight");
                break;

            case Direcao.Esquerda:
                playerAnim.PlayAnimation("AttackAnimationLeft");
                break;

            case Direcao.Cima:
                playerAnim.PlayAnimation("AtacckAnimationBack");
                break;

            case Direcao.Baixo:
                playerAnim.PlayAnimation("AtacckAnimationFront");
                break;
        }

        yield return new WaitForSeconds(0.4f);
        atacando = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !atacando) 
        {
            StartCoroutine(Atacar());
        }

        if (!atacando) 
        {
            //movimentar 
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


            //idle
            if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                switch (direcaoAtual)
                {
                    case Direcao.Direita:
                        playerAnim.PlayAnimation("IdlePurpleKingRightAnimation");
                        break;

                    case Direcao.Esquerda:
                        playerAnim.PlayAnimation("IdlePurpleKingLeftAnimation");
                        break;

                    case Direcao.Cima:
                        playerAnim.PlayAnimation("ThePurpleKingWalkAnimationBack");
                        break;

                    case Direcao.Baixo:
                        playerAnim.PlayAnimation("IdlePurpleKingAnimation");
                        break;
                }
            }
        }

    }
}