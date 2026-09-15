using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public float velocidade = 5f;
    public float vida = 50f;
    public bool estaVivo = true;

    [Header("Ataque Settings")]
    public bool estaAtancando = false;

    [Header("Catscene Settings")]
    public Transform pontoCentro;
    public bool catsceneAtiva = false;

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


    void Awake()
    {
        velocidade = 1f;    
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(Cutscene());
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
            Debug.Log("Boss Derrotado!");
        }
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
}
