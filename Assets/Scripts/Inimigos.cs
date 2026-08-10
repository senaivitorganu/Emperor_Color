using UnityEngine;
using UnityEngine.Video;

public class Inimigos : MonoBehaviour
{
    public float velocidadeInimigo = 2f;
    public Transform alvo;
    public float vidaInimigo = 5;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidadeInimigo * Time.deltaTime);
    }
}
