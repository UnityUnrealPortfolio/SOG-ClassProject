using UnityEngine;

/// <summary>
/// Fire a laser when user clicks on fire button (left mouse/spacebar/touchscreen)
/// </summary>
public class Gun : MonoBehaviour
{
    //the laser to fire
    [SerializeField] private GameObject redLaserPrefab;
    [SerializeField] private GameObject blueLaserPrefab;
    [SerializeField] private float cooldownTime = 1f;
    [SerializeField] private Transform leftGun;
    [SerializeField] private Transform rightGun;

    private float timer = 0f;
    private int gunCounter = 0;//refers to which gun is firing,left or right 0 - left, 1 - right
    private void Update()
    {
        //run down timer every frame
        timer = timer - Time.deltaTime;
       
        //check for left mouse click and cooldown done
       if(Input.GetMouseButtonDown(0) == true && timer < 0f)
        {
            //decide if left or right gun to fire based on gun counter
            if (gunCounter == 0)
            {
                //fire/spawn a laser from left gun position
                Instantiate(redLaserPrefab, leftGun.position, Quaternion.identity);
            }
            else if (gunCounter == 1)
            {
                //fire/spawn a laser from right gun position
                Instantiate(blueLaserPrefab, rightGun.position, Quaternion.identity);
            }

            //increment gun counter
            gunCounter++;

            //if greater than 1, cycle back to zero - flip flop effect
            if(gunCounter > 1)
            {
                gunCounter = 0;
            }
                

            //wait some time
            timer = cooldownTime;
        }
    }
}
