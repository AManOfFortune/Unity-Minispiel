using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainScene;
    public GameObject optionsMenu;
    public AudioSource audioSource;
    public Slider volumeSlider;
    //public TextMeshProUGUI volumeValue;

    private void Start()
    {
    }

    public void SetVolume()
    {
        // Debug Messages
        Debug.Log("SetVolume called!");
        Debug.Log("Volume set to " + audioSource.volume);

        // Set the volume of the audio source
        audioSource.volume = volumeSlider.value;

        // Update the text of the volume value field
        //volumeValue.SetText($"{volumeSlider.value.ToString("N4")}");

        // Save the new volume value to the PlayerPrefs
        SaveVolume();
    }

    public void OnReturn()
    {
        optionsMenu.SetActive(false);
        mainScene.SetActive(true);
    }
    public void SaveVolume()
    {
        // Save the value of the volume slider to the PlayerPrefs
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        Debug.Log("SaveVolume called!");
    }

}
