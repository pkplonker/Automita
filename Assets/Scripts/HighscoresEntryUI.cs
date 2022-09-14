using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoresEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    public void UpdateScore(Highscore highscore, int rank)
    {
        if (highscore == null) return;
        rankText.text = "#" + rank;
        timeText.text = highscore.time.ToString("hh':'mm':'ss");
        coinText.text = "#" + highscore.gold;
        totalScoreText.text = highscore.GetTotalScore().ToString();
    }
    
}