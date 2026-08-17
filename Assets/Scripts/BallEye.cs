using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallEye : MonoBehaviour
{
    [Header("Atributos da Bola")]
    public float velocidade = 4f;

    [Header("Tiro")]
    public Transform alvo;
    private Vector2 direcao;

    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform; // vai procurar o player
        direcao = (alvo.position - transform.position).normalized; // pega posição do player
    }

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime); //codigo para o a bola ir na direção do player
    }

    private void OnTriggerEnter2D(Collider2D collision) // mesmo trigger do inimigo, quando trigger for ativo
    {
        if (collision.CompareTag("Player")) // vai fazer a coparação se tem a tag player
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }
    }
}
