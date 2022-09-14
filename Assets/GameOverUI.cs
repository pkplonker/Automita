using System;
using System.Collections;
using System.Collections.Generic;
using StuartH;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private int mainMenuIndex = 1;
    [SerializeField] private int gameIndex = 2;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Highscore highscore;
    [SerializeField] private ScoreHolder scores;

    private void Awake()
    {
        var scoreClone = ScriptableObject.Instantiate(highscore);
        scores.AddScore(scoreClone);
        var rank = scores.GetRank(highscore);
        
        TimeSpan time = TimeSpan.FromSeconds(highscore.time);
        scoreText.text = "You have ranked #" + rank + "\n";
        scoreText.text += "Time: " + time.ToString("hh':'mm':'ss");
        scoreText.text += "\n"+"Gold: " + highscore.gold + "\n";
        scoreText.text += "Final score: " + highscore.GetTotalScore();
        SaveFileHandler.Save(scores);
    }

    public void TryAgain() => SceneManager.LoadScene(gameIndex);
    public void Menu() => SceneManager.LoadScene(mainMenuIndex);
}