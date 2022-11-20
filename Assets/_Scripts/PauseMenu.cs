using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
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
        SceneManager.LoadScene("Title Screen");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
}
