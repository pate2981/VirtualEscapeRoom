using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public AudioSource backgroundMusic; // Background music component
    public float maxVolume = 1.0f;  // Maximum volume
    public float minVolume = 0.0f;

    // Sets the volumbe of the AudioSource
    public void setVolume(float volume)
    {
        volume = Mathf.Clamp(volume, minVolume, maxVolume); // Clamp the volume between min and max
        backgroundMusic.volume = volume;    // Set the volume of the audiosource
    }

    // Set the volume based on a slider value (0-1)
    public void OnSliderValueChanged(float sliderValue)
    {
        setVolume(sliderValue);
    }
}
