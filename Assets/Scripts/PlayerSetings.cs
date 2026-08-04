using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetings : MonoBehaviour
{
    public float velocidade = 5f;

    public PlayerAnimationController playerAnim;

    void Update()
    { 
        if (Input.GetAxisRaw("Horizontal") == -1) 
        {
            transform.position -= transform.right * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkLeftAnimation");
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.position += transform.right * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkRightAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position -= transform.up * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += transform.up * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimationBack_");
        }
    }
}