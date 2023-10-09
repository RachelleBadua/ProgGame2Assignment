using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score = 0;
    public static float TotalScore = 0;
    public Text ScoreText;
    private float Scoreboard = 0;
    
    public void Awake()
    {
        // If there is an instance, and it's not me, delete myself. 
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //Instance = this;
        //DontDestroyOnLoad(Instance);
        //Scoreboard = TotalScore + Score;
        //ScoreText.text = "Your Score: " + Scoreboard;
    }

    public void Start()
    {
        Scoreboard = TotalScore + Score;
        ScoreText.text = "Your Score: " + Scoreboard;
    }

    public void IncrementScore()
    {
        Score += 50;
        Debug.Log("SCORE: " + Score + "pts");
        UpdateScoreBoard();
    }

    public void LoadNextLevel()
    {
        TotalScore += Score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("NEW LEVEL!!");
        Debug.Log("SCORE: " + TotalScore + "pts");
    }

    public void UpdateScoreBoard()
    {
        Scoreboard = TotalScore + Score;
        ScoreText.text = "Your Score: " + Scoreboard;
    }

    public void ResetTotalScore()
    {
        TotalScore = 0;
    }
}
