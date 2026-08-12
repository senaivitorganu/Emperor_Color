using UnityEngine;

public class InimigoAnimationController : MonoBehaviour
{
    [Header("Sprites Inimigo")]
    public Animator inimigoAnimator; // colocar animator 
    private string animacaoAtual;

    public void PlayAnimation(string animationName) // função para trocar de animação
    {
        if (animacaoAtual == animationName)
        {
            return;
        }
        animacaoAtual = animationName;

        inimigoAnimator.Play(animationName);
    }
}

