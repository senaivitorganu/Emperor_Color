using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandBoss : MonoBehaviour
{
    //Variaveis da Maão
    [Header("Hand Settings")]
    public float velocidade = 10f;
    private Vector2 direcao;
    private bool atacando = false;

    [Header("Player")]
    public Transform player; // vai pegar o objeto Player

    [Header("Animação")]
    public Animator animator; // pega o animator da mão

    [Header("Blocos")]
    public QuadrosController quadros;

    IEnumerator AparecerMao()
    {
        animator.Play(""); // vai exibir a animação da mão piscando
        
        float tempo = 0f;

        while (tempo < 2f) // vai dar um tempo de 2 segundos e ira seguir o eixo y so player
        {
            transform.position = new Vector2(transform.position.x, player.position.y); // vai seguir o eixo y do player
            tempo += Time.deltaTime;
            yield return null;
        }

        direcao = Vector2.left; // ira pegar a direção que tera que ir a mão
        atacando = true; // vai permitir que a mão ataque
    }

    void Start()
    {
        StartCoroutine(AparecerMao()); // vai chamar a função de aparecer a mão
    }

    private void Update()
    {

        if (atacando == true) 
        { 
            transform.Translate(direcao * velocidade * Time.deltaTime); // vai fazer a mão se mover em direção ao player
        }

        if(transform.position.x == -10) // quando chegar no final da tela a mão vai ser destruida
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }


    }
}
