using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene"); //current game scene name (needs to be adjusted if changed)
    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game was quit (does not work in Play Mode)");
    }
}