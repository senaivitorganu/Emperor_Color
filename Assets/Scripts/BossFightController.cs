using UnityEngine;
using System.Collections;

public class BossFightController : MonoBehaviour
{
    public static BossFightController instance;

    [Header("HandBoss")]
    public GameObject PrefabHand;
    public Transform SpawnPoint;

    [Header("Player")]
    public Transform player;

    [Header("Controles")]
    private bool nascerMao = true;
    private bool podeSpawnarMao = true;
    private bool NascerBoss = false;
    public GameObject boss;

    [Header("Conexões")]
    public BossController bossController;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        boss.SetActive(false);
        Debug.Log("Desativado)");
        StartCoroutine(SpawnHand());
    }

    void Update()
    {
        if (FaseSetting.instance.blocosPintados >= 70 && boss != null) 
        {
            NascerBoss = true;
            boss.SetActive(true);
        }

        if (bossController.catsceneAtiva == true) 
        {
            StartCoroutine(DesativarHand());
            DestruirMaos();
        }
    }

    public void DestruirMaos()
    {
        HandBoss[] maos = FindObjectsOfType<HandBoss>();

        foreach (HandBoss mao in maos)
        {
            Destroy(mao.gameObject);
        }
    }


    IEnumerator DesativarHand() 
    {
        podeSpawnarMao = false;
        yield return new WaitForSeconds(30f);
        podeSpawnarMao = true;

    }

    IEnumerator SpawnHand()
    {
        if (podeSpawnarMao == true)
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
                mao.bossController = bossController;
            }
        }
    }
}
