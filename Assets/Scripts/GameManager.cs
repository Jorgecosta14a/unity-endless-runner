using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    [Header("Pontuação")]
    public int score;
    public TextMeshProUGUI scoreText; 

    [Header("Botões")]
    public GameObject playButton;
    public GameObject restartButton;



    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        
        Time.timeScale = 0f; 
        
        
        playButton.SetActive(true);
        restartButton.SetActive(false);
    }

    public void ComecarJogo()
    {
        playButton.SetActive(false); 
        Time.timeScale = 1f; 
    }

    void Update()
    {
        
        if (Time.timeScale > 0) 
        {
            score++; 
            scoreText.text = "Pontuação: " + (score / 10).ToString(); 
        }
    }

    public void Morrer()
    {
        Time.timeScale = 0f; 
        restartButton.SetActive(true); 
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}