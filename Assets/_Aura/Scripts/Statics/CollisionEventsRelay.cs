using System;
using UnityEngine;




/// <summary>
/// This static class relays messages between collision detectors and classes that want to be notified
/// of any collision
/// </summary>
public static class CollisionEventsRelay
{
    public static event Action OnShieldPickup;
    public static event Action OnWeaponPickupDetection;
    public static event Action OnHealthPickupDetection;

    public static void NotifyOfCollision(PickupBase pickupComponent)
    {
        switch (pickupComponent.pickupType)
        {
            case PickupType.SHIELD:
                OnShieldPickup();
                break;
            case PickupType.WEAPON:
                OnWeaponPickupDetection();
                break;
            case PickupType.HEALTH:
                OnHealthPickupDetection();
                break;
            default:
                Debug.Log("Type is not defined");
                break;
        }
    }


}
