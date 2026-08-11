using UnityEngine;

public class QuadrosController : MonoBehaviour
{
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        sp.enabled = false;
    }
    
    public void ShowQuadro()
    {
        sp.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && FaseSetting.instance.podePintar == true)
        {
            ShowQuadro();
        }
    }
}
