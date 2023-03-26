using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Load the saved volume value
        LoadVolume();
    }

    public void LoadVolume()
    {
        // Load the value of the volume slider from the PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1.0f);
    }
}
