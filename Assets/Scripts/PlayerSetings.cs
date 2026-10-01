// create by: Vitor Gabriel
// date: 05/08/2026 as 13:20
// update: 11/08/2026 as 09:05

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSetings : MonoBehaviour
{
    [Header("Atributos do Player")]
    public float velocidade = 5f; // velocidade
    public bool estaVivo = true; // se esta vivo
    public float dano = 3f; // dano

    [Header("Sprites do Player")]
    public PlayerAnimationController playerAnim; // coloca aonde esta Anim

    [Header("Desh")]
    public bool podeDesh = false; // verifica se pode desh
    public bool usandoDesh = false; // verifica se esta usando desh

    float velocidadeDesh = 10f; // velocidade de desh
    float tempoDesh = 0.5f; // tempo de desh

    [Header("Atributos de Ataque")]
    private bool atacando = false; // verifica se esta atacando
    public float radius; // tamanho do raio de ataque
    public LayerMask inimigos; // verificar inimigos

    [Header("Points de Ataque")]
    // colocando gameObjec da onde ira atacar
    public GameObject atackPointFront;
    public GameObject atackPointBack;
    public GameObject atackPointRight;
    public GameObject atackPointLeft;

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
                    BossController boss = enemyGameobject.GetComponent<BossController>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                    else if (boss != null)
                    {
                        boss.ReceberDano(dano);

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
                    BossController boss = enemyGameobject.GetComponent<BossController>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                    else if (boss != null)
                    {
                        boss.ReceberDano(dano);
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
                    BossController boss = enemyGameobject.GetComponent<BossController>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                    else if (boss != null)
                    {
                        boss.ReceberDano(dano);
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
                    BossController boss = enemyGameobject.GetComponent<BossController>();

                    if (inimigoIrregular != null)
                    {
                        inimigoIrregular.ReceberDano(dano);
                    }
                    else if (inimigoEye != null)
                    {
                        inimigoEye.vidaInimigo -= dano;
                    }
                    else if (boss != null)
                    {
                        boss.ReceberDano(dano);
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

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Fase03" || SceneManager.GetActiveScene().name == "Fase04" || SceneManager.GetActiveScene().name == "Fase05")
        {
            podeDesh = true; // caso seja a fase 3, ele vai poder usar desh
        }
        else
        {
            podeDesh = false; // caso nao seja a fase 3, ele nao vai poder usar desh
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !atacando) 
        {
            StartCoroutine(Atacar()); // caso apertar o botão esquerdo do mouse e ele nao estiver atacando, ele vai atacar
        }

        if (!atacando) 
        {
            //enquanto tiver usando desh não vai poder se movimentar
            if (usandoDesh)
            {
                return;
            }

            //movimentar 
            float movimentoX = Input.GetAxisRaw("Horizontal");
            float movimentoY = Input.GetAxisRaw("Vertical");

            Vector2 movimento = new Vector2(movimentoX, movimentoY).normalized; // normaliza o vetor de movimento para que a velocidade seja constante

            transform.position += new Vector3(movimento.x, movimento.y, 0) * velocidade * Time.deltaTime; // movimenta o player


            //soltar animação de andar
            if (Input.GetAxisRaw("Horizontal") == -1) // caso usar A colocar script andando para esquerda
            {
                direcaoAtual = Direcao.Esquerda;
                playerAnim.PlayAnimation("ThePurpleKingWalkLeftAnimation");
            }

            if (Input.GetAxisRaw("Horizontal") == 1) // caso usar D colocar script andando para direita
            {
                direcaoAtual = Direcao.Direita;
                playerAnim.PlayAnimation("ThePurpleKingWalkRightAnimation");
            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                direcaoAtual = Direcao.Baixo;
                playerAnim.PlayAnimation("ThePurpleKingWalkAnimation");
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
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

            // desh
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) 
            {
                UsarDesh(); // caso apertar o botão shift, ele vai usar desh
            }
        }

    }

    public void UsarDesh() 
    {
        if (podeDesh == true && usandoDesh == false) 
        {
            StartCoroutine(RealizarDesh()); // caso apertar o botão direito do mouse e ele nao estiver atacando, ele vai atacar
        }
        else
        {
            Debug.Log("Não pode usar desh");
            return;
        }
    }

    IEnumerator RealizarDesh() 
    { 
        usandoDesh = true;
        podeDesh = false;

        float tempo = 0f;


        if (direcaoAtual == Direcao.Esquerda)
        {
            playerAnim.PlayAnimation("DeshLeft");
        }
        else if (direcaoAtual == Direcao.Direita)
        {
            playerAnim.PlayAnimation("DeshRight");
        }
        else if (direcaoAtual == Direcao.Cima)
        {
            playerAnim.PlayAnimation("DeshBack");
        }
        else if (direcaoAtual == Direcao.Baixo)
        {
            playerAnim.PlayAnimation("DeshFront");
        }


        while (tempo < tempoDesh)
        {
            Vector3 direcaoDesh = Vector3.zero; // variavel que vai guardar a direção do desh

            switch (direcaoAtual)
            {
                case Direcao.Direita:
                    direcaoDesh = transform.right;
                break;

                case Direcao.Esquerda:
                    direcaoDesh = -transform.right;
                    break;

                case Direcao.Cima:
                    direcaoDesh = transform.up;
                    break;

                case Direcao.Baixo:
                    direcaoDesh = -transform.up;
                    break;
            }

            transform.position += direcaoDesh * velocidadeDesh * Time.deltaTime; // movimenta o player na direção do desh

            tempo += Time.deltaTime;

            yield return null;
        }

        usandoDesh = false;

        yield return new WaitForSeconds(5f); //esperar 5 segundos para poder usar desh novamente

        podeDesh = true; 
    }
}