using UnityEngine;
using System.Collections;

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
        inimigoAnim.PlayAnimation("EyeOfDarkProjectilesAttack");
        yield return new WaitForSeconds(0.3f);// vai dar um tempo de 0.3 segundos
        Instantiate(PrefabBall, SpawnPoint.position, Quaternion.identity);

        estaAtacando = false;
        
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
                estaAtacando= true;
                StartCoroutine(Atacar());
            }
        }
    }
}
