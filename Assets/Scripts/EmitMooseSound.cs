using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EmitMooseSound : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private SimpleAudioEvent mooseSoundEvent;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Yelp"))
        {
            mooseSoundEvent.Play(audioSource);
        }
    }
}
