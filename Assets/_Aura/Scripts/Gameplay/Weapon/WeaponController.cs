using UnityEngine;

/// <summary>
/// Controller hold reference to the two weapon types
/// It will hold reference to the currently equipped weapon.
/// It will upgrade/swap between weapon types based on either
/// pick up information or other factors
/// </summary>
public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponBase primaryWeapon;
    [SerializeField] private WeaponBase secondaryWeapon;
    [SerializeField]private WeaponBase equippedWeapon;//ToDo exposed for testing
   

    private void Awake()
    {
        //register our UpgradeWeapon() method with the collisionDetector.
        CollisionEventsRelay.OnWeaponPickupDetection += UpgradeWeapon;
    }
    private void Start()
    {
        InitializeWeaponController();
    }
    private void OnDisable()
    {
        CollisionEventsRelay.OnWeaponPickupDetection -= UpgradeWeapon;
    }
    private void UpgradeWeapon()
    {
        //turn off the primary weapon
        equippedWeapon.gameObject.SetActive(false);
        //turn on the secondary weapon
        secondaryWeapon.gameObject.SetActive(true);
        //set the equipped weapon to be the secondary weapon
        equippedWeapon = secondaryWeapon;
    }

    private void InitializeWeaponController()
    {
        equippedWeapon = primaryWeapon;
        equippedWeapon.gameObject.SetActive(true);
    }
}
