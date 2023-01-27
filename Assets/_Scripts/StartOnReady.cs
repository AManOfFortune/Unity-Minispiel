using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartOnReady : MonoBehaviour
{
    public bool startGame = false;

    private CenterTextUI _centerTextUI;
    public Timer _timer;
    public GameObject transparentBackground;

    // Start is called before the first frame update
    void Start()
    {
        _centerTextUI = FindObjectOfType<CenterTextUI>();
        _timer = FindObjectOfType<Timer>();

        _centerTextUI.setCenterText("EVERYBODY READY? JUMP!");
    }

    // Update is called once per frame
    void Update()
    {
        // As long as game is not started, check if all keys are pressed
        if (!startGame)
        {
            startGame = true;

            if(startGame)
            {
                _centerTextUI.ShowMessageFor("LETS GO!", 1);
                _timer.ContinueTimer();
                transparentBackground.SetActive(false);
            }
        }
    }
}
