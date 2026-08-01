using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool pulled = false;
    public float smooth = 3f;
    float pulledAngle = -90f;
    float restAngle = 0f;

    public AudioSource asource;
    public AudioClip pullSound;

    public LightingController lightingController;

    void Start() {
        // Snap to correct starting rotation instead of lerping from a default (0,0,0)
        float startAngle = pulled ? pulledAngle : restAngle;
        transform.localRotation = Quaternion.Euler(startAngle, 0, 0);
    }
    void Update()
    {
        float target = pulled ? pulledAngle : restAngle;
        Quaternion targetRot = Quaternion.Euler(target, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * smooth);
    }

    public void PullLever()
    {
        pulled = !pulled;
        if (asource != null && pullSound != null)
            asource.PlayOneShot(pullSound);

        if (lightingController != null)
            lightingController.ToggleLights();
    }
}

