using UnityEngine;

/// <summary>
/// Fire a laser when the user clicks on the left mouse button
/// we need it to have a cooldown of a certain amount of seconds
/// that is modifiable.(to avoid spamming)
/// </summary>     
public class WeaponBase : MonoBehaviour
{
    [SerializeField] private WeaponConfigSO weaponConfig;

    private float timer;//keep track of the cooldown as it runs down
    private void Start()
    {
        if(weaponConfig == null)
        {
            Debug.Log(gameObject.name);
        }
        else
        {
            timer = weaponConfig.coolDownTime;
        }

            
    }
    private void Update()
    {
        //run down the timer
        timer -= Time.deltaTime;

     

        if (Input.GetMouseButtonDown(0) && timer < 0f)
        {
           FireLaser();
        }
    }

    protected virtual void FireLaser()
    {
        //create a copy of the laser
        //place the copy in the scene
        //at the position of the weapon
        //start a cooldown of x amount of seconds before being able to fire another laser
        Instantiate(weaponConfig.laserPrefab,transform.position,Quaternion.identity);

        timer = weaponConfig.coolDownTime;
    }
}
