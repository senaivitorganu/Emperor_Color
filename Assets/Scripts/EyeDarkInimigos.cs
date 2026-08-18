using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EyeDarkInimigos : MonoBehaviour
{
    [Header("Atributos do Inimigo")]
    public float velocidadeInimigo = 2f;
    public float vidaInimigo = 2;
    public bool estaVivo = true;
    public bool estaAtacando = false;

    [Header("Perseguir")]
    public Transform player;
    public float distancePlayer;

    [Header("Sprites")]
    public InimigoAnimationController inimigoAnim;

    [Header("Poder")]
    public GameObject PrefabBall;
    public Transform SpawnPoint;

    IEnumerator Atacar() 
    {
        estaAtacando = true;

        if (estaAtacando == true && estaVivo == true) 
        {
            inimigoAnim.PlayAnimation("EyeOfDarkProjectilesAttack");
            Instantiate(PrefabBall, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);// vai dar um tempo de 1 segundos
        }

        estaAtacando = false;
        inimigoAnim.PlayAnimation("EyeOfDark");
    }

    IEnumerator Morrer() 
    {
        estaVivo = false;
        inimigoAnim.PlayAnimation("EyeOfDarkDie");
        yield return new WaitForSeconds(1f);// vai dar um tempo de 1 segundos
        FaseSetting.instance.InimigoMorreu(); // vai chamar a função de inimigo morreu
        Destroy(gameObject);
    }

    void Update()
    {
        distancePlayer = (player.transform.position - transform.position).magnitude;

        if (distancePlayer > 5 && estaVivo)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidadeInimigo * Time.deltaTime); //codigo para o inimigo seguir o player
        }
        
        if (distancePlayer <= 5 && estaVivo) 
        {
            if (!estaAtacando)
            {
                StartCoroutine(Atacar());
            }
        }

        if(vidaInimigo <= 0) 
        {
            StartCoroutine(Morrer());
        }
    }
}
