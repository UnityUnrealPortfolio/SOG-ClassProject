using UnityEngine;


/// <summary>
/// This class handles confining the owning gameobject to 
/// extents of the screen as defined by the designer
/// </summary>
public class ConfineToScreen : MonoBehaviour
{
    [Header("Extents of the screen")]
    [SerializeField] private float lowerExtent = -8f;
    [SerializeField] private float upperExtent = 10f;
    [SerializeField] private float leftExtent = -5.5f;
    [SerializeField] private float rightExtent = 5.5f;


    private void Update()
    {
        //check if ship has passed any of the extents
        //if so, keep it at the extent position (confine)

        HandleConfinement();
    }

    /// <summary>
    /// This method contains the ship within the defined extents of the screen
    /// </summary>
    private void HandleConfinement()
    {  

        if (transform.position.y > upperExtent == true)
        {
            transform.position = new Vector3(transform.position.x,
                upperExtent, 0f);
        }
        if (transform.position.y < lowerExtent == true)
        {
            transform.position = new Vector3(transform.position.x,
                lowerExtent, 0f);
        }
        if (transform.position.x > rightExtent == true)
        {
            transform.position  = new Vector3(rightExtent,
                transform.position.y, 0f);
        }
        if (transform.position.x < leftExtent == true)
        {
            transform.position = new Vector3(leftExtent,
                transform.position.y, 0f);
        }
    }
}
