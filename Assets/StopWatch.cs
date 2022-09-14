using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using StuartH;
using TMPro;

public class StopWatch : MonoBehaviour
{
    // Variables
    bool timerActive = false;
    float currentTime;
    public TextMeshProUGUI currentTimeText;
    [SerializeField] private Score score;

    private void OnDestroy()=>score.time = currentTime;
    private void OnEnable() => CountDown.OnGameStart += StartTimer;
    private void OnDisable() => CountDown.OnGameStart -= StartTimer;

    public void StartTimer()
    {
        timerActive = true;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true){
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }
}
