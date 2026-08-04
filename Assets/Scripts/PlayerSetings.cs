using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetings : MonoBehaviour
{
    public float velocidade = 5f; // velocidade 

    public PlayerAnimationController playerAnim; // coloca aonde esta script

    void Update()
    { 
        if (Input.GetAxisRaw("Horizontal") == -1) // caso usar A colocar script andando para esquerda
        {
            transform.position -= transform.right * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkLeftAnimation");
        }

        if (Input.GetAxisRaw("Horizontal") == 1) // caso usar D colocar script andando para direita
        {
            transform.position += transform.right * (Time.deltaTime * velocidade);
            playerAnim.PlayAnimation("ThePurpleKingWalkRightAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position -= transform.up * (Time.deltaTime * velocidade); // caso use o S colocar o script andando para baixo
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimation");
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += transform.up * (Time.deltaTime * velocidade); // caso apertar W colocar a sprite de costas
            playerAnim.PlayAnimation("ThePurpleKingWalkAnimationBack_");
        }
    }
}