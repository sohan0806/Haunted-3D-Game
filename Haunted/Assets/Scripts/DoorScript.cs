using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class DoorScript : MonoBehaviour
    {
        [Header("Door State")]
        public bool isOpen = false;
        public bool isLocked = false;
        
        [Header("Rotation Settings")]
        [SerializeField] private float openAngle = 90.0f;
        [SerializeField] private float closedAngle = 0.0f;
        [SerializeField] private float smoothSpeed = 3.0f;

        [Header("Audio Settings")]
        [SerializeField] private AudioClip openSound;
        [SerializeField] private AudioClip closeSound;
        [SerializeField] private AudioClip lockedSound;

        private AudioSource audioSource;
        private Quaternion targetRotation;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.spatialBlend = 1.0f; // Set to 3D Audio
            audioSource.playOnAwake = false;

            SetTargetRotation(isOpen ? openAngle : closedAngle);
            transform.localRotation = targetRotation;
        }

        private void Update()
        {
            if (Quaternion.Angle(transform.localRotation, targetRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.Slerp(
                    transform.localRotation, 
                    targetRotation, 
                    Time.deltaTime * smoothSpeed
                );
            }
        }

        public void ToggleDoor()
        {
            if (isLocked)
            {
                PlayAudio(lockedSound);
                Debug.Log("Door is locked!");
                return;
            }

            isOpen = !isOpen;
            SetTargetRotation(isOpen ? openAngle : closedAngle);
            PlayAudio(isOpen ? openSound : closeSound);
        }

        public void UnlockDoor()
        {
            isLocked = false;
        }

        private void SetTargetRotation(float yAngle)
        {
            targetRotation = Quaternion.Euler(0f, yAngle, 0f);
        }

        private void PlayAudio(AudioClip clip)
        {
            if (clip != null && audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}