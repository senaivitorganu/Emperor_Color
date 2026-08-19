using UnityEngine;

public class PortalNIvel : MonoBehaviour
{
    private SpriteRenderer sp;
    private Collider2D col;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        sp.enabled = false; // desativa o sprite renderer no início do jogo
        col.enabled = false; // desativa o collider do portal
    }

    
    void Update()
    {
        if(FaseSetting.instance.faseConcluida == true)//verifica se a variavel esta true
        {
            sp.enabled = true; // ativa o sprite renderer quando a fase for concluída
            col.enabled = true; // ativa o collider
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Proxima Fase");

        if (other.CompareTag("Player")) 
        {
            Debug.Log("Proxima Fase");
        }
    }
}
