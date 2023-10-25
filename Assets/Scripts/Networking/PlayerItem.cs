using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI playerName;  // TextField of the players username

    private Image backgroundImage;   // Players avatar

    [SerializeField] private Color highlightColor;
    [SerializeField] private GameObject leftArrowButton;  // Left arrow button to toggle avatars
    [SerializeField] private GameObject rightArrowButton; // Right arrow button to toggle avatars

    // Custom property
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();   // Synchronizes changes made when choosing avatar
    [SerializeField] private Image playerAvatar;  // Image of the player's avatar
    [SerializeField] private Sprite[] avatars;    // Sprite List of all Avatars


    Player player;  // Photon object that contains a reference to a player

    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }

    // Sets the player name to the nickname the user entered when connecting to lobby
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    // Gets called locally to a users PlayerItem
    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    // Function called when user clicks left arrow button to toggle avatar
    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
            //playerProperties["playerAvatar"] = avatarList.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);  // Synchronize players avatars across all devices in the room
    }

    // Function called when user clicks right arrow button to toggle avatar
    public void OnClickRightArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);  // Synchronize players avatars across all devices in the room
    }

    // Called when PlayerItems are modified
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        // Updates player image for the player that modified their avatar
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        // Checks that player has custom property named playerAvatar
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];    // Synchronizes changes to players avatars for devices in the room
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];    // Saves the avatar chosen
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
    }
}
