using UnityEngine;


/// <summary>
/// This is a class that implements attributes and behaviours
/// specific to the weapon pickup. It inherits from PickupBase
/// </summary>
public class WeaponPickup : PickupBase
{
    public override void HandleGettingPickedUp()
    {
        base.HandleGettingPickedUp();
        Debug.Log("Handling getting picked up from weapon pickup.");
    }
}
