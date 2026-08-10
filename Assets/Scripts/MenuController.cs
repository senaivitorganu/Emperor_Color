using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string NomeCenaJogo;
    [SerializeField] private string CenaGameOver = "GameOver";
    [SerializeField] private string MenuPrincipal = "MenuPrincipal";
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

    //menu que vai para game over
    public void GamerOver()
    {
        SceneManager.LoadScene(CenaGameOver);
    }
    
    // void que volta para o menu
    public void VoltarMenu() 
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}
