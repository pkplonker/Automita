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
    [SerializeField] private ScoreHolder scores;

    private void Awake()
    {
        scores.AddScore();
        var rank = scores.GetRank(scores.currentScore);
        TimeSpan time = TimeSpan.FromSeconds(scores.currentScore.time);
        scoreText.text = "You have ranked #" + rank + "\n";
        scoreText.text += "Time: " + time.ToString("hh':'mm':'ss");
        scoreText.text += "\n"+"Gold: " + scores.currentScore.gold + "\n";
        scoreText.text += "Final score: " + scores.currentScore.GetTotalScore();
        SaveFileHandler.Save(scores);
    }

    public void TryAgain() => SceneManager.LoadScene(gameIndex);
    public void Menu() => SceneManager.LoadScene(mainMenuIndex);
}