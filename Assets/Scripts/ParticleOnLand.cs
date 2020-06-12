using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
public class ParticleOnLand : MonoBehaviour
{
    private CharacterGrounding characterGrounding;

    [SerializeField]
    private GameObject landingParticle;
    [SerializeField]
    private Transform spawnTransform;

    private void Awake()
    {
        characterGrounding = GetComponent<CharacterGrounding>();
        characterGrounding.OnLand += HandleLand;
    }

    private void HandleLand()
    {
        Instantiate(landingParticle, spawnTransform.position, Quaternion.identity);
    }
}
