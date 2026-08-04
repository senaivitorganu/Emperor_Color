using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string NomeCenaJogo;
    [SerializeField] private GameObject painelMenuInical;

    // void para entar no jogo
    public void IniciarJogo() 
    {
        SceneManager.LoadScene(NomeCenaJogo);
    }

    // void para falar sobre o criadores
    void AbrirCreditos() 
    { 
    
    }

    // void para sair do jogo
    public void SairJogo() 
    {
        Application.Quit();
    }
}
