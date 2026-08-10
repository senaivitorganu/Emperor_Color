using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Inimigos : MonoBehaviour
{
    public float velocidadeInimigo = 2f;
    public Transform alvo;
    public float vidaInimigo = 5;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidadeInimigo * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colidiu!");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
