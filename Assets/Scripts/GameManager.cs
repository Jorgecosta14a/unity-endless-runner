using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // 1. Adicionámos esta linha para ele conhecer o texto moderno!

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    [Header("Pontuação")]
    public int score;
    public TextMeshProUGUI scoreText; // 2. Mudámos o tipo de texto aqui!

    [Header("Botões")]
    public GameObject playButton;
    public GameObject restartButton;

// ... o resto do código continua igualzinho para baixo ...

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        // 1. O jogo começa CONGELADO (Tempo = 0)
        Time.timeScale = 0f; 
        
        // 2. Mostra o botão Play e esconde o botão Restart
        playButton.SetActive(true);
        restartButton.SetActive(false);
    }

    public void ComecarJogo()
    {
        playButton.SetActive(false); // Esconde o Play
        Time.timeScale = 1f; // DESCONGELA o tempo e o jogo arranca!
    }

    void Update()
    {
        // Só ganha pontos se o jogo estiver a correr (Tempo > 0)
        if (Time.timeScale > 0) 
        {
            score++; // Aumenta a pontuação
            scoreText.text = "Pontuação: " + (score / 10).ToString(); // O "/10" é para o número não subir estupidamente rápido
        }
    }

    public void Morrer()
    {
        Time.timeScale = 0f; // Congela o jogo porque bateste
        restartButton.SetActive(true); // Mostra o botão para jogar de novo
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // É vital repor o tempo antes de reiniciar!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}