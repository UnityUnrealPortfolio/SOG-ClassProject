using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidTwoConfigSO", menuName = "Scriptable Objects/AsteroidTwoConfig")]
public class AsteroidTwoConfigSO : ScriptableObject
{
    [Header("Smallest and Largest sizes")]
    [SerializeField] private float minAsteroidScale;
    [SerializeField] private float maxAsteroidScale;

    [Header("Scale cutoffs for small and medium asteroids")]
    [SerializeField] private float smallAsteroidScaleCutoff;
    [SerializeField] private float mediumAsteroidScaleCutoff;

    [Header("Min and Max Speeds based on scale")]
    [Header("Range for small asteroids")]
    [SerializeField] private float smallAsteroidMinMoveSpeed;
    [SerializeField] private float smallAsteroidMaxMoveSpeed;

    [Header("Range for medium asteroids")]
    [SerializeField] private float mediumAsteroidMinMoveSpeed;
    [SerializeField] private float mediumAsteroidMaxMoveSpeed;

    [Header("Range for large asteroids")]
    [SerializeField] private float largeAsteroidMinMoveSpeed;
    [SerializeField] private float largeAsteroidMaxMoveSpeed;

    [Header("Sprite Variations")]
    [SerializeField] private Sprite[] asteroidSprites;

    [Header("Min and Max Spin Speeds based on scale")]
    [Header("range for small asteroids")]
    
    [SerializeField] private float smallAsteroidMinSpeed;
    [SerializeField] private float smallAsteroidMaxSpeed;

    [Header("range for medium asteroids")]
    
    [SerializeField] private float mediumAsteroidMinSpeed;
    [SerializeField] private float mediumAsteroidMaxSpeed;

    [Header("range for large asteroids *anything larger than medium scale cutoff")]
    
    [SerializeField] private float largeAsteroidMinSpeed;
    [SerializeField] private float largeAsteroidMaxSpeed;

    [Header("AudioFX")]
    [SerializeField] private AudioClip takeDamageFX;

    //private cache of randomSpeed
    public float RandomSpinSpeed { get;private set; }
    public Vector3 GetRandomScale()
    {
        //get the random scale
        float randomScaleValue = Random.Range(minAsteroidScale, maxAsteroidScale);

        //return the random scale
        return  new Vector3(randomScaleValue, randomScaleValue, randomScaleValue);
    }

    public float GetRandomSpinSpeed(float randomScaleValue)
    {
        float randomSpeed = 0f;

        if (randomScaleValue < smallAsteroidScaleCutoff)
        {
            randomSpeed = Random.Range(smallAsteroidMinSpeed, smallAsteroidMaxSpeed);
        }
        else if (randomScaleValue > smallAsteroidScaleCutoff || randomScaleValue < mediumAsteroidScaleCutoff)
        {
            randomSpeed = Random.Range(mediumAsteroidMinSpeed, mediumAsteroidMaxSpeed);
        }
        else
        {
            randomSpeed = Random.Range(largeAsteroidMinSpeed, largeAsteroidMaxSpeed);
        }

        return randomSpeed;
    }

    public float GetRandomSpeedBasedOnScale(float randomScaleValue)
    {
        float randomSpeed = 0f;

        if (randomScaleValue < smallAsteroidScaleCutoff)
        {
            randomSpeed = Random.Range(smallAsteroidMinMoveSpeed, smallAsteroidMaxMoveSpeed);
        }
        else if (randomScaleValue > smallAsteroidScaleCutoff || randomScaleValue < mediumAsteroidScaleCutoff)
        {
            randomSpeed = Random.Range(mediumAsteroidMinMoveSpeed, mediumAsteroidMaxMoveSpeed);
        }
        else
        {
            randomSpeed = Random.Range(largeAsteroidMinMoveSpeed, largeAsteroidMaxMoveSpeed);
        }

        return randomSpeed;
    }

    public Sprite GetRandomSprite()
    {
        //set a random sprite
        int randomIndex = Random.Range(0, asteroidSprites.Length);

        //select a random sprite using the index
        Sprite randomSprite = asteroidSprites[randomIndex];

        return randomSprite;    
    }

    public AudioClip GetTakeDamageFx()
    {
        return takeDamageFX;
    }
}
