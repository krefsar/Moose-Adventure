using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerMovement))]
public class SoundOnJump : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerMovement moveController;

    [SerializeField]
    private AudioClip jumpSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        moveController = GetComponent<PlayerMovement>();
        moveController.OnJump += HandleJump;
    }

    private void HandleJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
