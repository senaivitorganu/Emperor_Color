using UnityEngine;
using System.Collections;

public class BossFightController : MonoBehaviour
{
    [Header("HandBoss")]
    public GameObject PrefabHand;
    public Transform SpawnPoint;

    [Header("Player")]
    public Transform player;

    [Header("Controles")]
    private bool nascerMao = true;

    void Start()
    {
        StartCoroutine(SpawnHand());
    }


    IEnumerator SpawnHand()
    {
        while (nascerMao)
        {
            if (FaseSetting.instance.faseConcluida)
            {
                nascerMao = false;
                break;
            }

            yield return new WaitForSeconds(5f);
            GameObject novaMao = Instantiate(PrefabHand, SpawnPoint.position, Quaternion.identity);
            HandBoss mao = novaMao.GetComponent<HandBoss>();
            mao.player = player;
        }
    }
}
