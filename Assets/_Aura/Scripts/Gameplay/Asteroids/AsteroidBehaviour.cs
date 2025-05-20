
using System;
using UnityEngine;

/// <summary>
/// This class defines base behaviour of an asteroid.
/// which is to move down in the world when spawned at a random speed decided
/// at the start of life, and 
/// to take damage from lasers and the ship. (try make speed depend on size)
/// </summary>
public class AsteroidBehaviour : MonoBehaviour
{
    #region Exposed Fields
    [Header("Reference to configuration scriptable object")]
    [SerializeField] private AsteroidConfigSO asteroidData; 
    #endregion

    #region Hidden Fields
    //reference to asteroid visual game object
    private Transform asteroidVisualTransform;

    //reference to asteroid visual sprite renderer
    private SpriteRenderer asteroidVisualRenderer;

    //cache of asteroid's random speed set at start of asteroid's life
    private float asteroidSpeed; 
    #endregion

    #region Mono Core Loop Callbacks
    private void Awake()
    {
        //set up all references

        //get the asteroid visual which is the first child
        asteroidVisualTransform = transform.GetChild(0);

        //get the SpriteRenderer which is part of the asteroid visual components
        asteroidVisualRenderer = asteroidVisualTransform.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        //Initialize asteroid
        SetAsteroidSpeed();
        SetAsteroidSprite();
        SetAsteroidScale();
    }

    private void Update()
    {
        //move down at 'asteroid speed' modified for frame rate variation
        transform.Translate(Vector2.down * asteroidSpeed * Time.deltaTime);
    }
    #endregion

    #region Mono Physics Callbacks

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "laser")
        {
            Destroy(collision.gameObject);

            HandleDestruction();
        }
    } 
    #endregion

    #region Asteroid Utility
    private void HandleDestruction()
    {
        //play a particle effect
        //play a destruction sound
        //remove from the scene
        Destroy(gameObject);
    } 
    #endregion

    #region Asteroid Initialization
    private void SetAsteroidSpeed()
    {
        //get random value between min and max and cache
        float randomSpeed = asteroidData.GetRandomSpeed();

        asteroidSpeed = randomSpeed;
    }

    private void SetAsteroidScale()
    {
        asteroidVisualTransform.localScale = asteroidData.GetRandomScale();
        
    }

    private void SetAsteroidSprite()
    {
        asteroidVisualRenderer.sprite = asteroidData.GetRandomSprite();
    }
    #endregion
}
