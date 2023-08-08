using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource pointScored;
    public AudioSource gameOverSound;
    public BirdScript bird;
    public  int highScore;
    private const string HighScoreKey = "HighScore";
    public  Text highScoreText;

    [ContextMenu("Increase Score")]

    void Start()
    {
          GameObject birdObject = GameObject.FindGameObjectWithTag("Bird");

        if (birdObject != null)
        {
            bird = birdObject.GetComponent<BirdScript>();
        }
        else
        {
            Debug.LogError("LogicManagerScript not found. Make sure you have a GameObject with the tag 'Logic' in the scene.");
        }

        LoadHighScore();
        UpdateHighScoreText();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore+=scoreToAdd;
        scoreText.text= playerScore.ToString();
        pointScored.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        
        gameOverScreen.SetActive(true);
        if (bird.birdIsAlive)
        {
            gameOverSound.Play();
        }
        SaveHighScore(playerScore);
        
    }

    public void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            UpdateHighScoreText();
        }
    }

    public  void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public  void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }
    
}
