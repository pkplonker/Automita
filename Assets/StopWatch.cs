using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatch : MonoBehaviour
{
    // Variables
    bool timerActive = false;
    float currentTime;
    public Text currentTimeText;
    
    
    // Starts the timer at the beginning of the game
    void Start()
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
