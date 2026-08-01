using UnityEngine;

public class MapPickup : MonoBehaviour
{
    public AudioClip pickupSound;

    public void PickupMap()
    {
        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        MapUI.Instance.UnlockMap();
        MapUI.Instance.OpenMap();

        Destroy(gameObject);
    }
}