using System;
using UnityEngine;

public class AsteroidTwoBehaviour : MonoBehaviour
{
    [SerializeField] private AsteroidTwoConfigSO asteroidTwoData;
    [SerializeField] private Transform asteroidVisualTransform;
    [SerializeField] private SpriteRenderer asteroidVisual;
    [SerializeField] private AsteroidTwoSpin spinBehaviour;
    

    [SerializeField] private int maxHealth = 100;


    //phone book, notifies subscribers when asteroid takes damage
    public event Action<int> OnTakeDamage;


    private int currentHealth = 0;

    //set randomly at start
    private float asteroidTwoSpeed;
    private void Awake()
    {
        //initialize asteroid properties
        SetRandomScaleAndSpeeds();

        SetRandomSprite();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        //fall down in the world
        transform.Translate(Vector2.down * asteroidTwoSpeed * Time.deltaTime);
    }

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
    }

    private void TakeDamage(int damageAmount)
    {
        //reduce current health by a value
        //if current health is less than or equal to zero
        //then destroy the asteroid

        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        //pass this information to the subscribers (calling subscribers)
        OnTakeDamage?.Invoke(currentHealth);

        //inform audio fx manager to play audio
        FindFirstObjectByType<AudioFXManager>().PlayAudioFx(asteroidTwoData.GetTakeDamageFx());

    }

    private void SetRandomScaleAndSpeeds()
    {
        //get a random scale from asteroid data
        asteroidVisualTransform.localScale = asteroidTwoData.GetRandomScale();
        float scaleValue = asteroidVisualTransform.localScale.x;

        //use the random scale to also get a random spin speed and pass to the spin component
        spinBehaviour.SetRandomSpeed(asteroidTwoData.GetRandomSpinSpeed(scaleValue));

        //use random scale to also get a random move speed
        asteroidTwoSpeed = asteroidTwoData.GetRandomSpeedBasedOnScale(scaleValue);
    }


    private void SetRandomSprite()
    {
        //set the asteroidVisual to use that sprite
        asteroidVisual.sprite = asteroidTwoData.GetRandomSprite();
    }

    public void HandleDestruction()
    {
        //play a particle fx
        //play a sound
        //inform game manager
        //remove from the scene
        Destroy(gameObject);
    }
}
