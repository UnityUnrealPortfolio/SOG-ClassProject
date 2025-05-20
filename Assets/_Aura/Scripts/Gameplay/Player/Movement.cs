using UnityEngine;

/// <summary>
/// This class receives input from keyboard to move the ship
/// left right, up and down. it modifies the input with a speed 
/// value and corrects for different frame rates
/// </summary>
public class Movement : MonoBehaviour
{
    [Tooltip("speeds up or slows down ship movement")]
    [SerializeField] private float speedModifier = 3f;

  

    private void Update()
    {
        HandleMovement();

    }

    /// <summary>
    /// Receives keyboard input, modifies with speedModifier and 
    /// scales for frame rates
    /// </summary>
    private void HandleMovement()
    {
        //listen for W,A,S,D and Arrow input
        float xAxisInput = Input.GetAxis("Horizontal");
        float yAxisInput = Input.GetAxis("Vertical");

        //If A or D or Right or Left arrow input comes in ->move in X axis left or right
        //if W or S or Up or Down arrow input comes int -> move in Y axis up or down
        //modify with a speed value
        //make the movement frame rate independent
        transform.Translate(xAxisInput * speedModifier * Time.deltaTime, yAxisInput * speedModifier * Time.deltaTime, 0f);

    }
}
