using System;
using UnityEngine;


/// <summary>
/// This component is responsible for detecting collision 
/// on the player and notifying relevant components e.g weapon, shield, health,audio
/// </summary>
public class CollisionDetectionBehaviour : MonoBehaviour
{
    //events for collision notification
    public event Action OnAsteroidCollision;
    public event Action OnHealthPickupCollision;
    public event Action OnShieldPickupCollision;
    public event Action OnWeaponPickupCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //filter collisions
        if (collision.CompareTag("asteroid"))
        {
            //notify of asteroid collision
            OnAsteroidCollision?.Invoke();
            
        }
        else if (collision.CompareTag("shield"))
        {
            //notify of shield pickup collision
        }
        else if (collision.CompareTag("health"))
        {
            //notify of health pickup collision
        }
        else if (collision.CompareTag("weapon"))
        {
            //notify of weapon pickup collision
        }
    }
}
