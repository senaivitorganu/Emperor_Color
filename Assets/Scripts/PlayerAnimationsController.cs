using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Sprites Player")]
    public Animator playerAnimator; // colocar animator 

    public void PlayAnimation(string animationName) // função para trocar de animação
    {
        playerAnimator.Play(animationName);
    }
}
