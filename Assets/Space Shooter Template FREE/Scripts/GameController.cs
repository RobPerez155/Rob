using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public Canvas startCanvas;
    public Canvas pauseCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public Canvas livesCanvas;
    public GameObject winGraphic;
    public Player player;
    public LevelController levelController;
    public TMP_Text scoreText;

    private int _currentScore;

    void Start()
    {   //This is how we set up the start menu to prevent the game from starting before player clicks start button
        startCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(false);
        livesCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        levelController.gameObject.SetActive(false);

        _currentScore = 0;
        UpdateScoreText();
    }

    public void StartGame()
    {
        startCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        livesCanvas.gameObject.SetActive(true);

        player.gameObject.SetActive(true);
        levelController.gameObject.SetActive(true);
    }

    public void PauseGame(bool pause)
    {
        pauseCanvas.gameObject.SetActive(pause);
        //#43 we are using timescale to pause the game, pause will either be equal to true or false
        if (pause)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        // todo: save high score
    }

    public void Replay()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
        //Ternary Statement
        //HighScoresControl.Instance.AddHighScore(_currentScore) ? winGraphic.SetActive(true) : winGraphic.SetActive(false);
    private void CheckAndDisplayWin()
    {

        if (HighScoresControl.Instance.AddHighScore(_currentScore))
        {
            winGraphic.SetActive(true);
        }
        else
        {
            winGraphic.SetActive(false);
        }
    }

    public void IncrementScore(int points)
    {
        _currentScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {_currentScore}";
    }
}
