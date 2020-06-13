using UnityEngine;

public class ParticleOnYelp : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab;
    [SerializeField]
    private Transform spawnTransform;

    private void Update()
    {
        if (Input.GetButtonDown("Yelp"))
        {
            Instantiate(particlePrefab, spawnTransform.position, Quaternion.identity, spawnTransform);
        }
    }
}
