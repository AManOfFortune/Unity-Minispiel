using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle fullscreenToggle;
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFullscreen(bool isFullscreen)
    {
        // Set the game to be played in fullscreen or windowed mode
        Screen.fullScreen = isFullscreen;
    }
}
