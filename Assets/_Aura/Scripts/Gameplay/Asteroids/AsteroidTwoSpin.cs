using UnityEngine;

/// <summary>
/// This component to apply a random spin speed and direction
/// to its gameobject
/// </summary>
public class AsteroidTwoSpin : MonoBehaviour
{
    //spin related properties
    private int[] directions = { -1, 1 }; //-1 - anticlockwise, 1 - clockwise
    private float randomSpeed;
    private int currentSpinDirection = -1;
    

    private void Start()
    {
        currentSpinDirection = directions[Random.Range(0, directions.Length)];
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * randomSpeed * currentSpinDirection * Time.deltaTime);
    }

    public void SetRandomSpeed( float spinSpeed)
    {  
        randomSpeed = spinSpeed;
    }
}
