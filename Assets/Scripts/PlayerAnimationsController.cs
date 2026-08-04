using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Sprites Player")]
    public Animator playerAnimator; // colocar animator 

    public void PlayAnimation(string animationName) 
    {
        playerAnimator.Play(animationName);
    }
}
