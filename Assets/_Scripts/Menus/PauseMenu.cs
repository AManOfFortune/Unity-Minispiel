using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject optionsMenu;
    public GameObject transparentBackground;
    public GameObject readyText;
    public GameObject startOnReady;
    private bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Title Screen 2"); //current title screen name (needs to be adjusted if changed)
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void PauseButton()
    {
        transparentBackground.SetActive(true);
        readyText.SetActive(false);
        startGame = startOnReady.GetComponent<StartOnReady>().startGame;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        if (!startGame)
        {
            readyText.SetActive(true);
            transparentBackground.SetActive(true);
        }
        else
        {
            transparentBackground.SetActive(false);
        }
    }

    public void OptionButton()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        
    }
}
