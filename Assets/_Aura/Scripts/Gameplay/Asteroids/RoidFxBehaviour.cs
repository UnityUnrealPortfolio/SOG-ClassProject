using UnityEngine;

public class RoidFxBehaviour : MonoBehaviour
{
    [Header("Time to destruction")]
    [SerializeField] private float timeToDestruction;

    [SerializeField] private ParticleSystem fx;

    private void Start()
    {
        fx.Play();
        Destroy(gameObject, timeToDestruction);//ToDo: convert to object pool implementation
    }
}
