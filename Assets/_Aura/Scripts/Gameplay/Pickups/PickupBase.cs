using UnityEngine;

/// <summary>
/// This class represents the default template for all pickups
/// </summary>
public abstract class PickupBase : MonoBehaviour
{
    [SerializeField] public PickupType pickupType;
   public virtual void HandleGettingPickedUp() 
    {
        Debug.Log("Handling getting picked up from base class.");
    }
}

public enum PickupType
{
    WEAPON,
    HEALTH,
    SHIELD
}
