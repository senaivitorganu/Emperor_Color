using UnityEngine;

public class DestruirParticula : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 0.5f); // vai destruir a particula depois de 0.5 segundos
    }
}
