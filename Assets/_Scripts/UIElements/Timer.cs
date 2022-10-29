using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text timertext;
    //public TextMeshProUGUI timertext;

    private float currentSeconds;
    private int currentMinutes;
    public int startingTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentMinutes = startingTime / 60;
        currentSeconds = startingTime % 60;
    }

    // Update is called once per frame
    void Update()
    {
        currentSeconds -= 1 * Time.deltaTime;
        if (currentSeconds < 0){
            currentSeconds += 60;
            currentMinutes--;
        }

        string currentSecondsText = (Mathf.Floor(currentSeconds)).ToString();
        string currentMinutesText = currentMinutes.ToString();
        
        //timertext.text = currentMinutesText + ":" + currentSecondsText;
    }
}
