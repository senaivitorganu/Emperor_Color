using UnityEngine;

public class QuadrosController : MonoBehaviour
{
    private SpriteRenderer sp;
    private bool quadroPintado = false;

    private Color corEscolhida; // variável para armazenar a cor escolhida pelo jogador
    public Color[] cores =
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.magenta,
        Color.cyan
    };// array de cores para os quadros

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        sp.enabled = false; // desativa o sprite renderer no início do jogo
    }
    
    public void ShowQuadro() // função para exibir os quadros
    {
        if (quadroPintado == false) 
        {
            Color corEscolhida = cores[Random.Range(0, cores.Length)];

            sp.enabled = true;
            sp.color = corEscolhida;
            quadroPintado=true;
            FaseSetting.instance.ContarBlocos(); // chama a função ContarBlocos() da classe FaseSetting para contar os blocos pintados
        }
    }

    public void UnloadBlocos()
    {
        sp.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) // trigger para detectar quando o jogador entra na área do quadro
    {
        if (other.CompareTag("Player") && FaseSetting.instance.podePintar == true)
        {
            ShowQuadro();
        }

        if (other.CompareTag("HandBoss")) 
        {
            UnloadBlocos(); // vai desativar o sprite renderer quando a mão do boss tocar no quadro
        }
    }
}
