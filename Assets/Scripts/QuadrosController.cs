using UnityEngine;

public class QuadrosController : MonoBehaviour
{
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        sp.enabled = false; // desativa o sprite renderer no início do jogo
    }
    
    public void ShowQuadro() // função para exibir os quadros
    {
        sp.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other) // trigger para detectar quando o jogador entra na área do quadro
    {
        if (other.CompareTag("Player") && FaseSetting.instance.podePintar == true)
        {
            ShowQuadro();
        }
    }
}
