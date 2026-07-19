using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Settings")]
    public float closeAngle = -90f;    // Changed to close angle (usually negative to swing it back into place)
    public float smoothSpeed = 3f;     
    
    [Header("Interaction Settings")]
    public float interactionDistance = 3f; 
    public Transform player;          

    private bool isOpen = true;        // Set to TRUE by default now!
    private Quaternion openRotation;
    private Quaternion closedRotation;

    void Start()
    {
        // Because the model is open by default, save the starting rotation as "open"
        openRotation = transform.localRotation;
        
        // Calculate the "closed" position by swinging it backwards into the doorway
        closedRotation = openRotation * Quaternion.Euler(0, closeAngle, 0);
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // Smoothly rotate toward whichever state is active
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothSpeed);

        // Check for player interaction
        if (player != null && Vector3.Distance(transform.position, player.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen; // Toggles between open and closed
            }
        }
    }
}