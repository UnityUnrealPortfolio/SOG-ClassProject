using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This component is responsible for giving feedback about asteroid damage to the player
/// using a health bar.
/// It receives the current health value of the asteroid and uses it to set the health bar value.
/// </summary>
public class AsteroidUIBehaviour : MonoBehaviour
{
    //reference to the health bar
    [SerializeField] private Image healthBarImage;
    [SerializeField] private AsteroidTwoBehaviour asteroidBehaviour;

    private void Awake()
    {
        asteroidBehaviour.OnTakeDamage += DisplayAsteroidDamage; 
    }

    private void OnDisable()
    {
        asteroidBehaviour.OnTakeDamage-= DisplayAsteroidDamage;
    }


    public void DisplayAsteroidDamage(int currentHealth)
    {
      
        float fillValue = currentHealth/100f;
        
        //modify the health bar value
        healthBarImage.fillAmount = fillValue;
    }
}
