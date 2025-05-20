using UnityEngine;

/// <summary>
/// This class defines a spin behaviour for each asteroid 
/// the speed and direction of spin are randomly set at the start
/// of life.
/// </summary>
public class SpinBehaviour : MonoBehaviour
{
    [SerializeField] private float minSpinSpeed;
    [SerializeField] private float maxSpinSpeed;


    private int[] spinDirections = new int[]{ 1,-1}; //can be either -1 0r 1
    private float spinSpeed;
    private int spinDirection;
    private void Start()
    {
        SetRandomSpinSpeedAndDirection();
    }
    private void Update()
    {
        transform.Rotate(0f,0f,spinSpeed *spinDirection* Time.deltaTime);
    }

    public void SetRandomSpinSpeedAndDirection()
    {
        //use Random.Range to get a spin speed to set 
        //at the start of life of this asteroid
        float randomSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        spinSpeed = randomSpeed;

        //use Random.Range to get random spin direction to
        //set at the start of life of this asteroid
        int randomIndex = Random.Range(0, spinDirections.Length);
        spinDirection = spinDirections[randomIndex];    
    }
}
