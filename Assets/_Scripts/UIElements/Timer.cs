using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Timer : MonoBehaviour
{
    public Text timertext;
    //public TextMeshProUGUI timertext;
    public CenterTextUI CenterTextController;
    public Text centerText;
    private StartOnReady _startOnReady;

    public float currentSeconds;
    public int currentMinutes;
    public int startingTime = 70;

    public bool runtimer;
    public bool endedtimer;

    // Start is called before the first frame update
    void Start()
    {
        _startOnReady = FindObjectOfType<StartOnReady>();

        StartTimer(startingTime);
        StopTimer();
    }

    // resets the timer and lets it start  
    public void StartTimer(int seconds)
    {
        ConvertTime(seconds);
        runtimer = true;
        endedtimer = false;
    }

    // convert any number of seconds to their respective minutes and seconds
    private void ConvertTime(int seconds)
    {
        currentMinutes = seconds / 60;
        currentSeconds = seconds % 60;
    }

    // stops the timer from ticking down
    public void StopTimer()
    {
        runtimer = false;
        endedtimer = true;
    }
    // lets the timer continue from where it stopped
    public void ContinueTimer()
    {
        runtimer = true;
        endedtimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(runtimer) {
            // subtract the time that has passed since the last update from the seconds
            currentSeconds -= 1 * Time.deltaTime;
            // if all 60 seconds have passed subtract 1 from the minute clock and reset the seconds clock
            if (currentSeconds < 0){
                currentSeconds += 60;
                currentMinutes--;
            }

            // if the timer reached 0 stop it
            if (currentMinutes < 0) { runtimer = false; }
        }

        // sends a signal once to centertext to change the textbox and resets the timer to a nice number
        if(!runtimer && !endedtimer) {
            endedtimer = true;
            currentMinutes = 0;
            currentSeconds = 0;

            _startOnReady.GameEnd(true);
            _startOnReady.startGame = false;
        }

        UpdateTimer();
    }
    
    // updates the timer, 3 minutes, 2 seconds -> 03:02
    void UpdateTimer()
    {
        string currentSecondsText = "";
        string currentMinutesText = "";

        // if the number has only one digit add a leading 0, to make sure it has 2 digits
        if (currentSeconds < 10) { currentSecondsText = "0"; }
        if (currentMinutes < 10) { currentMinutesText = "0"; }

        // round down the seconds from 1.3345 to 1 and convert the times to strings
        currentSecondsText += (Mathf.Floor(currentSeconds)).ToString();
        currentMinutesText += currentMinutes.ToString();

        timertext.text = currentMinutesText + ":" + currentSecondsText;
    }
}
