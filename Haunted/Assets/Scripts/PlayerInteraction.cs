using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRadius = 2.0f;
    public LayerMask doorLayer;

    void Update()
    {
        // Check if player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
{
    // Look for colliders within our reach radius
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRadius, doorLayer);
    
    foreach (var collider in hitColliders)
    {
        // 1. Fixed: Look for their "Door" script instead of InteractiveDoor
        DoorScript.Door door = collider.GetComponentInParent<DoorScript.Door>();
        if (door != null)
        {
            // 2. Fixed: Flip the built-in "open" boolean flag
            door.open = !door.open; 
            break; 
        }
    }
}

    // Visualizes the interaction radius in the Scene View
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
