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

    //[SerializeField] private TextMeshProUGUI volumeValue;

    private void Start()
    {
        // Initialize the options menu with the current volume
        volumeSlider.value = audioSource.volume;
        
    }

    public void SetVolume()
    {
        // Set the volume of the audio source
        //volumeValue.SetText($"{Value.ToString("N4")}");
        audioSource.volume = volumeSlider.value;
        Debug.Log("SetVolume called!");
        Debug.Log("Volume set to " + audioSource.volume);
    }

    public void OnReturn()
    {
        optionsMenu.SetActive(false);
        mainScene.SetActive(true);
    }
}
