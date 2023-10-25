using UnityEngine;
using UnityEngine.UI;

public class BackgroundAudio : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        // Initialize the slider's value to the current audio source volume.
        volumeSlider.value = audioSource.volume;
        // Add a listener to the slider's value change event.
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // Update the audio source volume based on the slider value.
        audioSource.volume = volume;
    }
}
