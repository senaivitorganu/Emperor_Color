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
    public float dano = 3f; // dano

    [Header("Sprites do Player")]
    public PlayerAnimationController playerAnim; // coloca aonde esta Anim

    [Header("Atributos de Ataque")]
    private bool atacando = false; // verifica se esta atacando

    // colocando gameObjec da onde ira atacar
    public GameObject atackPointFront;
    public GameObject atackPointBack;
    public GameObject atackPointRight;
    public GameObject atackPointLeft;

    public float radius; // tamanho do raio de ataque
    public LayerMask inimigos; // verificar inimigos

    // enum guarda valores igual uma lista, so que diferente de vetores que guarda numeros, ele guarda nomes.
    public enum Direcao // Enum com todas as direções
    {
        Baixo,
        Cima,
        Esquerda,
        Direita
    }
    public Direcao direcaoAtual = Direcao.Baixo; //variavel que vai indicar qual a direcao atual


    public void darDano()
    {
        switch (direcaoAtual) 
        {

            case Direcao.Baixo:
                // verifica se tem inimigos na frente do player e da dano a eles
                Collider2D[] enemyDown = Physics2D.OverlapCircleAll(atackPointFront.transform.position, radius, inimigos);
                foreach (Collider2D enemyGameobject in enemyDown)
                {
                    Debug.Log("Inimigo atingido");
                    Inimigos inimigoIrregular = enemyGameobject.GetComponent<Inimigos>();
                    EyeDarkInimigos inimigoEye = enemyGameobject.GetComponent<EyeDarkInimigos>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                }
                break;

            case Direcao.Cima:
                // verifica se tem inimigos na frente do player e da dano a eles
                Collider2D[] enemyUp = Physics2D.OverlapCircleAll(atackPointBack.transform.position, radius, inimigos);
                foreach (Collider2D enemyGameobject in enemyUp)
                {
                    Debug.Log("Inimigo atingido");
                    Inimigos inimigoIrregular = enemyGameobject.GetComponent<Inimigos>();
                    EyeDarkInimigos inimigoEye = enemyGameobject.GetComponent<EyeDarkInimigos>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                }
                break;

            case Direcao.Esquerda:
                // verifica se tem inimigos na frente do player e da dano a eles
                Collider2D[] enemyLeft = Physics2D.OverlapCircleAll(atackPointLeft.transform.position, radius, inimigos);
                foreach (Collider2D enemyGameobject in enemyLeft)
                {
                    Debug.Log("Inimigo atingido");
                    Inimigos inimigoIrregular = enemyGameobject.GetComponent<Inimigos>();
                    EyeDarkInimigos inimigoEye = enemyGameobject.GetComponent<EyeDarkInimigos>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                }
                break;

            case Direcao.Direita:
                // verifica se tem inimigos na frente do player e da dano a eles
                Collider2D[] enemyRight = Physics2D.OverlapCircleAll(atackPointRight.transform.position, radius, inimigos);
                foreach (Collider2D enemyGameobject in enemyRight)
                {
                    Debug.Log("Inimigo atingido");
                    Inimigos inimigoIrregular = enemyGameobject.GetComponent<Inimigos>();
                    EyeDarkInimigos inimigoEye = enemyGameobject.GetComponent<EyeDarkInimigos>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                }
                break;
        }
    }


    IEnumerator Atacar() 
    {
        atacando = true;

        switch (direcaoAtual)
        {
            case Direcao.Direita:
                playerAnim.PlayAnimation("AttackAnimationRight"); // exiber ataque para direita
                darDano();
                //fim do case
                break;

            case Direcao.Esquerda:
                playerAnim.PlayAnimation("AttackAnimationLeft"); // exiber ataque para esquerda
                darDano();

                //fim do case
                break;

            case Direcao.Cima:
                playerAnim.PlayAnimation("AtacckAnimationBack"); // exiber ataque para cima
                darDano();

                // fim do case
                break;

            case Direcao.Baixo:
                playerAnim.PlayAnimation("AtacckAnimationFront"); // exiber ataque para baixo
                darDano();
                // fim do case
                break;
        }

        yield return new WaitForSeconds(0.4f);
        atacando = false;
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(atackPointFront.transform.position, radius);
       Gizmos.DrawWireSphere(atackPointBack.transform.position, radius);
       Gizmos.DrawWireSphere(atackPointRight.transform.position, radius);
       Gizmos.DrawWireSphere(atackPointLeft.transform.position, radius);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !atacando) 
        {
            StartCoroutine(Atacar()); // caso apertar o botão esquerdo do mouse e ele nao estiver atacando, ele vai atacar
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
                        playerAnim.PlayAnimation("IdlePurpleKingRightAnimation"); // idle para direita
                        break;

                    case Direcao.Esquerda:
                        playerAnim.PlayAnimation("IdlePurpleKingLeftAnimation"); // idle para esquerda
                        break;

                    case Direcao.Cima:
                        playerAnim.PlayAnimation("ThePurpleKingWalkAnimationBack"); // idle para cima
                        break;

                    case Direcao.Baixo:
                        playerAnim.PlayAnimation("IdlePurpleKingAnimation"); // idle para baixo
                        break;
                }
            }
        }

    }
}