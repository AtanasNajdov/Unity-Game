using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject Description;
    [SerializeField] private GameObject specialImage1;
    [SerializeField] private GameObject specialImage2;
    [SerializeField] private GameObject specialImage3;
    [SerializeField] private GameObject specialImage4;
    [SerializeField] private GameObject specialImage5;

    private int score;
    public int Score => score;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();

            gameOver.SetActive(false);
            pauseButton.SetActive(false); // Hide the pause button at the start
            Description.SetActive(true);
            specialImage1.SetActive(false); // Hide the special image at the start
            specialImage2.SetActive(false);
            specialImage3.SetActive(false);
            specialImage4.SetActive(false);
            specialImage5.SetActive(false);
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        Description.SetActive(false);
        specialImage1.SetActive(false); // Hide the special image at the start
        specialImage2.SetActive(false);
        specialImage3.SetActive(false);
        specialImage4.SetActive(false);
        specialImage5.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes.SpeedMultiplier = 1f; // Reset the speed multiplier
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        if (pauseButton != null)
        {
            pauseButton.SetActive(true); // Show the pause button when the game starts
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        Description.SetActive(false);

        if (pauseButton != null)
        {
            pauseButton.SetActive(false); // Hide the pause button on game over
        }

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        isPaused = false;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void IncreaseScore()
    {
        score += 5;
        scoreText.text = score.ToString();
        CheckScore(); // Add this line to check the score
    }

    private void CheckScore()
    {
        if (score == 60)
        {
            specialImage1.SetActive(true);
            Pipes.SpeedMultiplier = 1.2f; // Increase speed by 20%
        }
        else
        {
            specialImage1.SetActive(false);
        }
        if (score == 120)
        {
            specialImage2.SetActive(true);
            Pipes.SpeedMultiplier = 1.4f; // Further increase speed
        }
        else
        {
            specialImage2.SetActive(false);
        }
        if (score == 180)
        {
            specialImage3.SetActive(true);
            Pipes.SpeedMultiplier = 1.6f; // Further increase speed
        }
        else
        {
            specialImage3.SetActive(false);
        }
        if (score == 240)
        {
            specialImage4.SetActive(true);
	    specialImage5.SetActive(true);
            Pipes.SpeedMultiplier = 1.8f; // Further increase speed
            GameOver(); // End the game

        }
        else
        {
            specialImage4.SetActive(false); 
	    specialImage5.SetActive(false);
        }
    }
}
