using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaioAtack : MonoBehaviour
{
    public CircleCollider2D colisor;

    void Start()
    {
        colisor = GetComponent<CircleCollider2D>();

        colisor.enabled = false; // desativa o colisor do raio

        StartCoroutine(TimeRaio());
    }

    IEnumerator TimeRaio() 
    {
        yield return new WaitForSeconds(1f); // espera 1 segundo antes de destruir o raio
        colisor.enabled = true; // ativa o colisor do raio
        yield return new WaitForSeconds(3f); // espera 3 segundo antes de destruir o raio
        Destroy(gameObject); // destroi o raio
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }

        if (other.CompareTag("Blocos"))
        {
            QuadrosController quadro = other.GetComponent<QuadrosController>();

            if (quadro != null)
            {
                quadro.UnloadBlocos();
            }
        }
    }
}
