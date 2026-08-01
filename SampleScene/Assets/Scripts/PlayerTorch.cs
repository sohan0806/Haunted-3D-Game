using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    public GameObject torchModel;   // torch mesh attached to player's hand/camera, disabled by default
    public Light torchLight;        // the actual Light component on the torch
    public AudioSource asource;
    public AudioClip toggleOnSound, toggleOffSound;

    public bool hasTorch = false;
    private bool torchOn = false;

    void Start()
    {
        if (torchModel != null) torchModel.SetActive(false);
        if (torchLight != null) torchLight.enabled = false;
    }

    void Update()
    {
        if (hasTorch && Input.GetKeyDown(KeyCode.F))
        {
            ToggleTorch();
        }
    }

    public void EquipTorch()
    {
        hasTorch = true;
        if (torchModel != null) torchModel.SetActive(true);
        // Torch starts off until player presses F
    }

    void ToggleTorch()
    {
        torchOn = !torchOn;
        if (torchLight != null) torchLight.enabled = torchOn;

        if (asource != null)
            asource.PlayOneShot(torchOn ? toggleOnSound : toggleOffSound);
    }
}
