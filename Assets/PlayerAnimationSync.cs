using Photon.Pun;
using UnityEngine;

public class PlayerAnimationSync : MonoBehaviourPun
{
    [SerializeField]private Animator animator;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        
        // Handle animation changes for the local player
        bool isWalking = Input.GetKey(KeyCode.W); // Example: Use the "W" key for walking.

        // Update the animation parameter for the local player
        animator.SetBool("IsWalking", isWalking);

        // Synchronize the parameter for remote players
        photonView.RPC("SyncAnimationParameter", RpcTarget.OthersBuffered, isWalking);
        
    }

    [PunRPC]
    private void SyncAnimationParameter(bool isWalking)
    {
        // Update the animation parameter for remote players
        animator.SetBool("IsWalking", isWalking);
    }
}
