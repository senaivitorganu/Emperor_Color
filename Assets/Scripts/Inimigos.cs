using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Inimigos : MonoBehaviour
{
    // variais de atributos do player
    [Header("Atributos do Inimigo")]
    public float velocidadeInimigo = 2f;
    public float vidaInimigo = 5;

    //variaveis de seguir o player
    [Header("Seguir o Player")]
    public Transform alvo;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidadeInimigo * Time.deltaTime); //codigo para o inimigo seguir o player

        if (vidaInimigo <= 0) 
        {
            FaseSetting.instance.InimigoMorreu(); // vai chamar a função de inimigo morreu
            Destroy(gameObject); // caso a vida do inimigo seja menor ou igual a 0 ele vai ser destruido
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // quando trigger for ativo
    {
        if (other.CompareTag("Player")) // vai fazer a coparação se tem a tag player
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }
    }
}
