using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnReady : MonoBehaviour
{
    public bool startGame = false;
    public bool endGame = false;
    public GameObject confetti;

    private Dictionary<int, KeyCode> jumpKeys = new();
    private PlayerUI _playerUI;
    private CenterTextUI _centerTextUI;
    public Timer _timer;
    public GameObject transparentBackground;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        confetti.SetActive(false);
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

            if (startGame)
            {
                _centerTextUI.ShowMessageFor("LETS GO!", 1);
                _timer.ContinueTimer();
                transparentBackground.SetActive(false);
            }
        }
        if(startGame & !endGame)
        {
            RunGame();
        }
    }

    void RunGame()
    {
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

            endGame = true;
            foreach (PlayerController playerController in playerControllers)
            {
                isAlive = playerController.isAlive;
                //if a player is still alive, end game is set to false again
                if (isAlive)
                {
                    endGame = false;
                }
            }
        if (endGame)
        {
            bool win = false;
            GameEnd(win);
        }
    }

    public void GameEnd(bool win)
    {
        if (!win)
        {
            startGame = false;
            _timer.StopTimer();
            _centerTextUI.ShowMessageFor("Players Lose!",10);
            confetti.SetActive(true);
        }
        else
        {
            _centerTextUI.ShowMessageFor("Players Win!",10);
            confetti.SetActive(true);
        }
        StartCoroutine(GameEndCoroutine());
    }

    IEnumerator GameEndCoroutine()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("GameOver");
    }
}
