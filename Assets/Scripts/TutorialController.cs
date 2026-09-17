using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialController : MonoBehaviour
{
    public static TutorialController instance;

    public enum TutorialState
    {
        Mover,
        Atacar,
        Pintar,
        Finalizado
    }

    public TutorialState etapaAtual;
    public TextMeshProUGUI tutorialText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        etapaAtual = TutorialState.Mover;
        StartCoroutine(atualizarAtacar());
    }

    void AvancarEtapa()
    {
        if (etapaAtual < TutorialState.Finalizado)
        {
            etapaAtual++;
        }
    }

    void Update()
    {
        switch (etapaAtual)
        {
            case TutorialState.Mover:
                tutorialText.text = "Use WASD to move.";
                break;
            case TutorialState.Atacar:
                tutorialText.text = "Press [LMB]🖱️ to attack.";
                break;
            case TutorialState.Pintar:
                tutorialText.text = "Paint the entire area to open the portal..";
                break;
            case TutorialState.Finalizado:
                tutorialText.text = "Enter the portal!";
                break;
        }


        if (FaseSetting.instance.podePintar == true)
        {
            etapaAtual = TutorialState.Pintar;
        }

        if (FaseSetting.instance.faseConcluida == true)
        {
            etapaAtual = TutorialState.Finalizado;
        }
    }


    IEnumerator atualizarAtacar() 
    {
        yield return new WaitForSeconds(4f);
       AvancarEtapa();
    }
}
