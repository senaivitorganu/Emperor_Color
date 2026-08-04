using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class BotaoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // variavel que guardar o texto
    public TextMeshProUGUI texto;

    //variaveis que salva a cores que usarei no codigo a baixo
    public Color corNormal = Color.white;
    public Color corHover = Color.yellow;

    //void para quando iniciar a cena
    void Start()
    {
        texto.color = corNormal;
    }

    // essa void diz que quando o mouse passar por cima do texto chamar o corHover
    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.color = corHover;
    }

    //essa void diz que quando o mouse sair de cima do texto voltar para cor normal 
    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = corNormal;
    }
}
