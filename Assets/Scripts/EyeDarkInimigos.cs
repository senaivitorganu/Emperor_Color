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
        if(estaAtacando == true) 
        {
            inimigoAnim.PlayAnimation("EyeOfDarkProjectilesAttack");
            Instantiate(PrefabBall, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);// vai dar um tempo de 1 segundos
        }

        estaAtacando = false;
        inimigoAnim.PlayAnimation("EyeOfDark");
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

        if(vidaInimigo <= 0) 
        {
            Destroy(gameObject);
            FaseSetting.instance.InimigoMorreu(); // vai chamar a função de inimigo morreu
        }
    }
}
