using System;
using UnityEngine;

public class AsteroidTwoBehaviour : MonoBehaviour
{
    #region Exposed Fields
    [SerializeField] private AsteroidTwoConfigSO asteroidTwoData;
    [SerializeField] private Transform asteroidVisualTransform;
    [SerializeField] private SpriteRenderer asteroidVisual;
    [SerializeField] private AsteroidTwoSpin spinBehaviour; 
    #endregion


    //phone book, notifies subscribers when asteroid takes damage
    public event Action<float> OnTakeDamage;

    //ToDo: convert to property
    private int currentHealth = 0;

    //what is the max health of this asteroid instance based on it's scale
    private float thisAsteroidMaxHealth = 0;
    //set randomly at start
    private AsteroidType asteroidType;

    //set randomly at start
    private float asteroidTwoSpeed;


    #region Mono Core Loop Callbacks
    private void Awake()
    {
        //initialize asteroid type
        SetRandomType();

        //initialize asteroid properties
        InitializeAsteroidProperties();
        
        //if grey asteroid - set random grey sprite
        //else if brown - set random brown sprite
        SetRandomSprite();
    }

    private void Update()
    {
        //fall down in the world
        transform.Translate(Vector2.down * asteroidTwoSpeed * Time.deltaTime);
    } 
    #endregion

    #region Mono Physics Callbacks
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("laser"))
        {

            LaserBehaviour laser = collision.GetComponent<LaserBehaviour>();

            //destroy asteroid
            TakeDamage(laser.GetDamageAmount());

            //destroy laser
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
           
            TakeDamage(asteroidTwoData.ShipDamagePoints);
        }

        else if (collision.gameObject.CompareTag("planet"))
        {
            HandleDestruction();
        }
    }


    #endregion

    #region Initialization Logic
    private void SetRandomType()
    {
        //20% chance of being grey
        int randomIndex = UnityEngine.Random.Range(0, 11);

        if (randomIndex < 3)
        {
            asteroidType = AsteroidType.GREY;
        }
        else
        {
            asteroidType = AsteroidType.BROWN;
        }
    }
    private void InitializeAsteroidProperties()
    {
        //get a random scale from asteroid data
        asteroidVisualTransform.localScale = asteroidTwoData.GetRandomScale();
        float scaleValue = asteroidVisualTransform.localScale.x;

        //use the random scale to also get a random spin speed and pass to the spin component
        spinBehaviour.SetRandomSpeed(asteroidTwoData.GetRandomSpinSpeed(scaleValue));

        //use random scale to also get a random move speed
        asteroidTwoSpeed = asteroidTwoData.GetRandomSpeedBasedOnScale(scaleValue);

        //use random scale to set current health
        SetAsteroidMaxHealth(scaleValue);
    }
    private void SetAsteroidMaxHealth(float scaleValue)
    {
        //cache the max health of this asteroid instance
        thisAsteroidMaxHealth = asteroidTwoData.GetmaxHealthBasedOnScale(scaleValue);

        //initialize the current health to the max health
        currentHealth = asteroidTwoData.GetmaxHealthBasedOnScale(scaleValue);
    }
    private void SetRandomSprite()
    {
        //set the asteroidVisual to use based on type
        if (asteroidType == AsteroidType.GREY)
        {
        
          asteroidVisual.sprite = asteroidTwoData.GetRandomGreySprite();
        }
        else
        {
            asteroidVisual.sprite = asteroidTwoData.GetRandomBrownSprite();
        }
    }
    #endregion

    #region Damage and Destruction Utility
    private void TakeDamage(int damageAmount)
    {
     

        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {
            HandleDestruction();
        }

        //pass this information to the subscribers (calling subscribers)
        OnTakeDamage?.Invoke(currentHealth/thisAsteroidMaxHealth);

        //inform audio fx manager to play audio
        FindFirstObjectByType<AudioFXManager>().PlayAudioFx(asteroidTwoData.TakeDamageFX);

    }
    public void HandleDestruction()
    {
        //play a particle fx based on type
        if (asteroidType == AsteroidType.GREY)
        {
         Instantiate(asteroidTwoData.GreyRoidFx, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(asteroidTwoData.BrownRoidFx, transform.position, Quaternion.identity);
        }
        //play a sound
        //inform game manager
        //remove from the scene
        Destroy(gameObject);
    } 
    #endregion
}

public enum AsteroidType
{
    GREY,
    BROWN
}
