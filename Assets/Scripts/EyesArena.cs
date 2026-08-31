using UnityEngine;
using System.Collections;

public class EyesArena : MonoBehaviour
{
    public Animator animator;

    public float tempoMinimo = 1f;
    public float tempoMaximo = 5f;

    void Start()
    {
        StartCoroutine(Piscar());
    }

    IEnumerator Piscar()
    {
        while (true)
        {
            // Cada olho escolhe um tempo diferente
            float tempoAleatorio = Random.Range(tempoMinimo, tempoMaximo);

            // Espera
            yield return new WaitForSeconds(tempoAleatorio);

            // Executa a animação de piscar
            animator.Play("EyesArenaLadinho");

            // Espera a animação terminar
            yield return new WaitForSeconds(0.5f);
        }
    }
}
