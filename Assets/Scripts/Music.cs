using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public static Music instance;

    [Header("Musicas")]
    public AudioClip musicaMenu;
    public AudioClip musicaGameplay;
    public AudioClip musicaBoss;

    private AudioSource audioSource;
    private string nomeCena;


    private void Awake()
    {
        // Verifica se já existe uma instância do Music
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>(); // procura o componente AudioSource no GameObject
    }

    void Start()
    {
        nomeCena = SceneManager.GetActiveScene().name;
    }

    private void TocarMusica(AudioClip musica)
    {
        audioSource.Stop();
        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        nomeCena = scene.name;
        if (nomeCena == "MenuPrincipal")
        {
            TocarMusica(musicaMenu);
        }
        else if (nomeCena == "Fase01")
        {
            TocarMusica(musicaGameplay);
        }
    }

    public void TocarBoss() 
    {
        TocarMusica(musicaBoss);
    }
}
