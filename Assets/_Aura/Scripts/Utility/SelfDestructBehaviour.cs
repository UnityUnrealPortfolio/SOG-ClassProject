using UnityEngine;


/// <summary>
/// This is a utility script that destroys whatever gameobject
/// it's attached to after some time
/// </summary>
public class SelfDestructBehaviour : MonoBehaviour
{
    [Header("Time to destruction")]
    [SerializeField] private float timeToDestruction;

    private void Start()
    {
        Destroy(gameObject,timeToDestruction);
    }
}
