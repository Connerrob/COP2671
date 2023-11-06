using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    // UI elements for display
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI highScoreText;

    public Button startOver;
    public Button pauseGame;

    // main menu, instruction menu, and pause menu screens
    public GameObject menuScreen;
    public GameObject instructionMenu;
    public GameObject pauseMenu;

    public SpawnManager spawnManager;

    public bool gameActive;

    //setting Countdown time and score 
    private float countdownTime = 60f;
    private int score = 0;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        ShowMenu();
    }
    public void StartGame()
    { 
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        pauseGame.gameObject.SetActive(true);
        // Starts the, updates UI elements, and hides the menu screen
        UpdateTimerUI();
        UpdateScoreUI();
        
        pauseGame.gameObject.SetActive(true);
        menuScreen.SetActive(false);

        gameActive = true;

        spawnManager.StartSpawn();

        UpdateTimer();

    }
    public void ShowMenu()
    {
        // Shows the main menu and hides the instruction menu.
        menuScreen.SetActive(true);
        instructionMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        UpdateTimer();
    }
    void UpdateTimer()
    {
        // Updates the game timer if the game is active and there's time left
        if (gameActive && countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime < 0)
            {
                countdownTime = 0;
            }
            UpdateTimerUI();
        }
        else
        {
            if (gameActive)
            {
                // Handle game over if time runs out.
                GameOver();
            }
        }
    }
    public void UpdateScore(int value)
    {
        // Update the players score
        score += value;
        UpdateScoreUI();
    }

    public void ShowInstructions()
    {
        // Shows the instruction menu and hides the main menu
        instructionMenu.SetActive(true);
        menuScreen.SetActive(false);
    }
    void UpdateScoreUI()
    {
        // Updates the displayed player score
        scoreText.text = "Score: " + score;
    }
    void UpdateTimerUI()
    {
        // Updates the displayed game timer
        string seconds = Mathf.Floor(countdownTime).ToString("00");
        timerText.text = "Time Left: " + seconds;
    }
    public void GameOver()
    {
        // Handles the game over state, displays UI elements, and updates high score
        gameOver.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        startOver.gameObject.SetActive(true);
        pauseGame.gameObject.SetActive(false);

        gameActive = false;

        if (score > highScore)
        {
            // Update and save the high score if the current score is higher
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore;
        }
    }
    public void RestartGame()
    {
        // Restarts the game by showing the main menu and reloading the scene
        ShowMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            // Resume the game
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            // Pause the game
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
