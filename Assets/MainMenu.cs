using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int mainMenuIndex = 1;
    [SerializeField] private int gameIndex = 2;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Score score;

    private void Awake()
    {
        TimeSpan time = TimeSpan.FromSeconds(score.time);
        scoreText.text = "Your time: " + time.ToString("hh':'mm':'ss");
        scoreText.text += "\n"+"Your gold: " + score.gold + "\n";
        scoreText.text += "Final score: " + score.time * (score.gold / 4);
    }

    public void TryAgain() => SceneManager.LoadScene(gameIndex);
    public void Menu() => SceneManager.LoadScene(mainMenuIndex);
}