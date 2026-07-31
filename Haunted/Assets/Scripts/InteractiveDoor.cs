using UnityEngine;

public class InteractiveDoor : MonoBehaviour
{
    [Header("Door Settings")]
    public bool isOpen = false;
    public float openAngle = 90f;
    public float smoothSpeed = 5f;

    private Quaternion closedRotation;
    private Quaternion targetRotation;

    void Start()
    {
        // Save the starting rotation as the "closed" state
        closedRotation = transform.localRotation;
        targetRotation = closedRotation;
    }

    void Update()
    {
        // Smoothly rotate toward the target rotation matrix
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            // Rotate around the Y-axis to open
            targetRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
        }
        else
        {
            // Return to starting position
            targetRotation = closedRotation;
        }
    }
}
