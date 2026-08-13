using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallEye : MonoBehaviour
{
    [Header("Atributos da Bola")]
    public float velocidade = 5f;

    [Header("Tiro")]
    public Transform alvo;

    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform; // vai procurar o player
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidade * Time.deltaTime); //codigo para o inimigo seguir o player
    }

    private void OnTriggerEnter2D(Collider2D collision) // mesmo trigger do inimigo, quando trigger for ativo
    {
        if (collision.CompareTag("Player")) // vai fazer a coparação se tem a tag player
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }
    }
}
