using Photon.Voice.PUN;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceChat : MonoBehaviour
{
    [SerializeField]
    private Button MuteButton;  // Button to toggle mute and unmute

    public AudioSource audioSource;

    public Sprite muteSprite;
    public Sprite unmuteSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function used to toggle mute and unmute
    public void ToggleMute()
    {
        Image icon = MuteButton.GetComponent<Image>();
        Sprite sprite = icon.sprite;
        string spriteName = sprite.name;

        // If the player is unmuted, mute them
        if (spriteName == unmuteSprite.name)
        {
            audioSource.mute = true;
            icon.sprite = muteSprite;
        }
        // If the player is muted, unmute them
        else if (spriteName == muteSprite.name)
        {
            audioSource.mute = false;
            icon.sprite = unmuteSprite;
        }
    }
}
