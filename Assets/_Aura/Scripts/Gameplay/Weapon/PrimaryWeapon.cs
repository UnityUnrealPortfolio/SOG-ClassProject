using UnityEngine;

public class PrimaryWeapon:WeaponBase
{
    protected override void FireLaser()
    {
        base.FireLaser();

        Debug.Log("Firing Primary Weapon!");
    }
}
