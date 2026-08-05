using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Sprites Player")]
    public Animator playerAnimator; // colocar animator 
    private string animacaoAtual;

    public void PlayAnimation(string animationName) // função para trocar de animação
    {
        if (animacaoAtual == animationName)
        {
            return;
        }
        animacaoAtual = animationName;

        playerAnimator.Play(animationName);
    }
}