using System.Collections;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public float velocidade = 5f;
    public float vida = 50f;
    public bool estaVivo = true;
    public bool podeMover = true;

    [Header("Boss Bar")]
    public Transform bossBar;  //RectTransform é o componente usado para controlar posição, tamanho e escala de elementos da UI.
    public Transform bossBarImage; // Image é o componente usado para exibir imagens na UI, como a barra de vida do boss.
    public float vidaMax;
    private float larguraMaximaBarra;

    [Header("Ataque Settings")]
    public bool estaAtancando = false;

    [Header("Catscene Settings")]
    public Transform pontoCentro;
    public bool catsceneAtiva = false;

    [Header("Movimentações")]
    public Transform pontoEsquerda;
    public Transform pontoDireita;

    private int lado;

    [Header("Raio Atack")]
    public Transform pontoEsquerdo;
    public Transform pontoDireito;
    public Transform pontoCima;
    public Transform pontoBaixo;

    public GameObject raioPrefab;

    private float contadorAtaque = 0f;
    public float tempoEntreAtaques = 10f;

    [Header("Animations Settings")]
    public Animator animator;

    [Header("Conexões")]
    public PlayerSetings player;
    public GameObject EyesArena;


    void Awake()
    {
        velocidade = 1f;    
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(Cutscene());

        vidaMax = vida;
        larguraMaximaBarra = bossBar.localScale.y; // pega a largura atual da barra de vida
    }

    void Update()
    {
        if (estaVivo == true && catsceneAtiva == false)
        {
            contadorAtaque += Time.deltaTime;

            if (contadorAtaque >= tempoEntreAtaques)
            {
                EscolherAtaque();
                contadorAtaque = 0f;
            }
        }

        if (vida <= 0)
        {
            EyesArena.SetActive(false);
            podeMover = false; // define que o boss não pode mais se mover
            StartCoroutine(Morrer());
        }
    }

    public void ReceberDano(float dano)
    {
        if (vida <= 0)
        {
            return; // se a vida já estiver zerada, não faz nada
        }

        vida -= dano;
        StartCoroutine(animaHit());

        float porcetagemVida = vida / vidaMax; // calcula a porcentagem de vida restante

        bossBar.localScale = new Vector3(bossBar.localScale.x, larguraMaximaBarra * porcetagemVida, bossBar.localScale.z); // atualiza a largura da barra de vida com base na porcentagem de vida restante

    }

    IEnumerator Cutscene()
    {
        float guardarVelocidade = player.velocidade; // guarda a velocidade atual do player
        player.velocidade = 0; // zera a velocidade do player durante a catscene
        catsceneAtiva = true; // ativa a catscene

        //OBS: A função Mathf.Abs retorna o valor absoluto de um número, ou seja, remove o sinal negativo se houver. Isso é útil para comparar a diferença entre duas posições, independentemente da direção.
        while (Mathf.Abs(transform.position.y - pontoCentro.position.y) > 0.01f) // enquanto a diferença entre a posição atual e o ponto central for maior que 0.01 
        {
           float novoY = Mathf.MoveTowards(transform.position.y, pontoCentro.position.y, velocidade * Time.deltaTime); // calcula a nova posição Y do boss, movendo-o em direção ao ponto central com base na velocidade e no tempo decorrido

            transform.position = new Vector3(transform.position.x, novoY, transform.position.z); // atualiza a posição do boss com a nova posição Y calculada

            yield return null;
        }

        transform.position = new Vector3(transform.position.x, pontoCentro.position.y, transform.position.z); // garante que a posição final do boss seja exatamente no ponto central

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Transformar", true);
        yield return new WaitForSeconds(3f); // espera de 3 segundos

        catsceneAtiva = false; // desativa a catscene
        player.velocidade = guardarVelocidade; // restaura a velocidade do player após a catscene

        animator.SetBool("FimTransformação", true);
        velocidade = 5f; // Restaura a velocidade do boss após a catscene

        bossBar.gameObject.SetActive(true); // ativa a barra de vida do boss após a catscene
        bossBarImage.gameObject.SetActive(true); // ativa a imagem da barra de vida do boss após a catscene

        StartCoroutine(MoverBoss()); // inicia a movimentação do boss após a catscene
    }

    void EscolherAtaque()
    {
        //OBS: estamos usando 2 bibliotecas que possuem a função Random.Range, a do UnityEngine e a do System. Para evitar conflitos, estamos especificando que queremos usar a do UnityEngine.
        int ladoAtaque = UnityEngine.Random.Range(0, 2);
        

        if (ladoAtaque == 0)
        {
            Instantiate(raioPrefab, pontoEsquerdo.position, pontoEsquerdo.rotation);
            Instantiate(raioPrefab, pontoDireito.position, pontoDireito.rotation);
        }
        else
        {
            Instantiate(raioPrefab, pontoCima.position, pontoCima.rotation);
            Instantiate(raioPrefab, pontoBaixo.position, pontoBaixo.rotation);
        }
    }

    IEnumerator MoverBoss() 
    {
        while (estaVivo && podeMover == true)
        {
            yield return new WaitForSeconds(5f); // espera 5 segundo antes de escolher o próximo lado para se mover

            lado = UnityEngine.Random.Range(0, 2); // escolhe aleatoriamente entre 0 e 1 para determinar o lado do movimento

            if (lado == 0)
            {
                // Move para a esquerda
                while (Mathf.Abs(transform.position.x - pontoEsquerda.position.x) > 0.01f)
                {
                    float novoX = Mathf.MoveTowards(transform.position.x, pontoEsquerda.position.x, velocidade * Time.deltaTime);
                    transform.position = new Vector3(novoX, transform.position.y, transform.position.z);
                    yield return null;
                }
            }
            else
            {
                // Move para a direita
                while (Mathf.Abs(transform.position.x - pontoDireita.position.x) > 0.01f)
                {
                    float novoX = Mathf.MoveTowards(transform.position.x, pontoDireita.position.x, velocidade * Time.deltaTime);
                    transform.position = new Vector3(novoX, transform.position.y, transform.position.z);
                    yield return null;
                }
            }

            // Fica parado no lado por 20 segundos
            yield return new WaitForSeconds(20f);

            // Volta para o centro
            while (Mathf.Abs(transform.position.x - pontoCentro.position.x) > 0.01f)
            {
                float novoX = Mathf.MoveTowards(
                    transform.position.x,
                    pontoCentro.position.x,
                    velocidade * Time.deltaTime
                );

                transform.position = new Vector3(
                    novoX,
                    transform.position.y,
                    transform.position.z
                );

                yield return null;
            }

            yield return new WaitForSeconds(5f); // espera 5 segundo antes de escolher o próximo lado para se mover
        }
    }

    IEnumerator Morrer() 
    {
        bossBar.gameObject.SetActive(false); // desativa a barra de vida do boss
        estaVivo = false; // define que o boss não está mais vivo
        animator.SetBool("Morrer", true);
        yield return new WaitForSeconds(10f); // espera 1 segundo antes de destruir o boss
        Destroy(gameObject); // destroi o objeto do boss
        bossBarImage.gameObject.SetActive(false); // desativa a imagem da barra de vida do boss
    }

    IEnumerator animaHit() 
    {
        animator.SetBool("Hit", true);

        yield return new WaitForSeconds(0.5f); // espera 0.5 segundo antes de voltar para a animação de idle

        animator.SetBool("Hit", false);
    }
}
