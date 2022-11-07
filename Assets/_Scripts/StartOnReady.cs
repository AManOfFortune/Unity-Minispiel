using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartOnReady : MonoBehaviour
{
    public bool startGame = false;

    private Dictionary<int, KeyCode> jumpKeys = new();
    private PlayerUI _playerUI;
    private CenterTextUI _centerTextUI;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        // Get all Jump Input Keycodes
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

        foreach(PlayerController playerController in playerControllers)
        {
            jumpKeys[playerController.PlayerIndex] = playerController.jumpKey;
        }

        _playerUI = FindObjectOfType<PlayerUI>();
        _centerTextUI = FindObjectOfType<CenterTextUI>();
        _timer = FindObjectOfType<Timer>();

        _playerUI.ShowButtonsToPress(jumpKeys);
        _centerTextUI.setCenterText("EVERYBODY READY?");
    }

    // Update is called once per frame
    void Update()
    {
        // As long as game is not started, check if all keys are pressed
        if (!startGame)
        {
            startGame = true;

            foreach (var keyCodePlayerIndexPairs in jumpKeys)
            {
                // If a key is not pressed, startGame is set to false again
                if (!Input.GetKey(keyCodePlayerIndexPairs.Value))
                {
                    _playerUI.UnsetButtonPressed(keyCodePlayerIndexPairs.Key);
                    startGame = false;
                }
                else
                {
                    _playerUI.SetButtonPressed(keyCodePlayerIndexPairs.Key);
                }
            }

            if(startGame)
            {
                _centerTextUI.ShowMessageFor("LETS GO!", 1);
                _timer.ContinueTimer();
            }
        }
    }
}
