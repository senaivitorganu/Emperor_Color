using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform alvo;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidade * Time.deltaTime);
    }
}
