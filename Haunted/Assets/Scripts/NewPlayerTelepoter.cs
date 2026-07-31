using UnityEngine;

public class NewPlayerTelepoter : MonoBehaviour
{
    public Transform TeleportZoneObject;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {

            Vector3 localOffset = transform.InverseTransformPoint(other.transform.position);

            Quaternion relativeRotation = TeleportZoneObject.rotation * Quaternion.Inverse(transform.rotation);

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                
                // Fixed: Correct variable name and removed the .rotation chain
                other.transform.position = TeleportZoneObject.TransformPoint(localOffset);
                
                other.transform.rotation = relativeRotation * other.transform.rotation;

                cc.enabled = true;
            }
        }
    }
}
