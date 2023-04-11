using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeCntrl : MonoBehaviour
{
 public Slider volumeSlider;
    public Text volumeText;

    void Start()
    {
        // Load the current volume level from player prefs
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = volume;
        UpdateVolume(volume);
    }

    public void OnVolumeChanged(float volume)
    {
        // Update the volume level and save it to player prefs
        UpdateVolume(volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    void UpdateVolume(float volume)
    {
        // Set the volume level for all audio sources
        AudioListener.volume = volume;

        // Update the volume text to display the current level
        int volumePercent = Mathf.RoundToInt(volume * 100f);
        volumeText.text = "Volume: " + volumePercent + "%";
    }
    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
