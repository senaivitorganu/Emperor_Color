using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Collections;

public class Inimigos : MonoBehaviour
{
    // variais de atributos do inimigo
    [Header("Atributos do Inimigo")]
    public float velocidadeInimigo = 2f;
    public float vidaInimigo = 5;
    private bool estaVivo = true;

    //variaveis de seguir o player
    [Header("Seguir o Player")]
    public Transform alvo;

    [Header("Sprites Inimigo")]
    public InimigoAnimationController inimigoAnim;


    IEnumerator TomarDano() 
    { 
        velocidadeInimigo = 0; // vai zerar a velocidade do inimigo
        inimigoAnim.PlayAnimation("EnemyIrregularDamagingTake"); // vai exibir a animação de dano do inimigo
        yield return new WaitForSeconds(0.5f);// vai dar um tempo de 0.5 segundos para a animação

        velocidadeInimigo = 2; // vai voltar a velocidade do inimigo para 2
    }

    IEnumerator Morrer() 
    {
        if(estaVivo == false) 
        {
            inimigoAnim.PlayAnimation("EnemyIrregularDie"); // vai exibir a animação de morte do inimigo
            yield return new WaitForSeconds(0.5f);// vai dar um tempo de 0.5 segundos para a animação de morte do inimigo ser exibida
            FaseSetting.instance.InimigoMorreu(); // vai chamar a função de inimigo morreu
            Destroy(gameObject); // caso a vida do inimigo seja menor ou igual a 0 ele vai ser destruido
        }
    }

    public void ReceberDano(float dano) // função para receber dano
    {
        if (vidaInimigo > 0)
        {
            vidaInimigo -= dano; // vai subtrair a vida do inimigo com o dano recebido
            StartCoroutine(TomarDano()); // vai chamar a função de tomar dano
        }
        else
        { 
            StartCoroutine(Morrer()); // vai chamar a função de morrer
        }
    }

    void Update()
    {
        if (estaVivo == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidadeInimigo * Time.deltaTime); //codigo para o inimigo seguir o player
        }

        if (vidaInimigo <= 0 && estaVivo == true)
        {
            estaVivo = false;
            StartCoroutine(Morrer()); // vai chamar a função de morrer
        }
    }

    void OnTriggerEnter2D(Collider2D other) // quando trigger for ativo
    {
        if (other.CompareTag("Player")) // vai fazer a coparação se tem a tag player
        {
            SceneManager.LoadScene("GameOver"); // vai vim a tela de gameover
        }
    }
}
