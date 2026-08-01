using UnityEngine;

public class TorchPickup : MonoBehaviour
{
    public GameObject torchVisual; // the mesh child, so we can hide it once picked up
    public AudioClip pickupSound;

    public void Pickup(PlayerTorch playerTorch)
    {
        playerTorch.EquipTorch();

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject); // remove torch from the ground
    }
}
