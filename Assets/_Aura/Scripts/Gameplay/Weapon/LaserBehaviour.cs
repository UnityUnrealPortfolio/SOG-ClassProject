using UnityEngine;

/// <summary>
/// This class defines the default behaviour of lasers in the game
/// </summary>
public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float laserSpeed = 10f;

    [Tooltip("amount of damage this laser deals to asteroids")]
    [SerializeField] private int damageAmount = 20;

    private void Update()
    {
        //move laser up in the world every frame
        transform.Translate(Vector2.up * laserSpeed *  Time.deltaTime);
    }

    public int GetDamageAmount()
    {
        return damageAmount;
    }
}
