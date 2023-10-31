using Photon.Voice.PUN;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceChat : MonoBehaviour
{
    [SerializeField] private Button MuteButton;  // Button to toggle mute and unmute
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject player;

    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unmuteSprite;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = player.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey((KeyCode)KeyBind.Mute))
        {
            ToggleMute();
        }
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
