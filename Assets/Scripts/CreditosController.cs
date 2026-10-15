using System.Collections;
using UnityEngine;

public class CreditosController : MonoBehaviour
{
    [Header("Textos")]
    public RectTransform textoCreditos;
    public RectTransform areaCreditos;
    public GameObject textoFinal;

    [Header("Buttons")]
    public GameObject botaoVoltar;

    [Header("Configurações")]
    public float velocidade = 50f;

    void Awake()
    {
        textoFinal.SetActive(false);
        botaoVoltar.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(ScrollCreditos());
    }

    IEnumerator ScrollCreditos()
    {
        float alturaTexto = textoCreditos.rect.height;
        float alturaArea = areaCreditos.rect.height;
        float posicaoInicial = -alturaArea / 2 - alturaTexto / 2;
        float posicaoFinal = alturaArea / 2 + alturaTexto / 2;
        textoCreditos.anchoredPosition = new Vector2(0, posicaoInicial);
        while (textoCreditos.anchoredPosition.y < posicaoFinal)
        {
            textoCreditos.anchoredPosition += new Vector2(0, velocidade * Time.deltaTime);
            yield return null;
        }
        // Exibe o texto final e o botão de voltar
        textoFinal.SetActive(true);
        botaoVoltar.SetActive(true);
    }
}
