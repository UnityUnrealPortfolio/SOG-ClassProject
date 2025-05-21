using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidTwoConfigSO", menuName = "Scriptable Objects/AsteroidTwoConfig")]
public class AsteroidTwoConfigSO : ScriptableObject
{
    #region Exposed Sprite Properties
    [Header("Sprite Variations")]
    [SerializeField] private Sprite[] greyAsteroidSprites;
    [SerializeField] private Sprite[] brownAsteroidSprites;
    #endregion

    #region Exposed health properties
    [Header("Health properties")]
    [field: SerializeField] public int LargeAsteroidMaxHealth { get; private set; }
    [field: SerializeField] public int MediumAsteroidMaxHealth { get; private set; }
    [field: SerializeField] public int SmallAsteroidMaxHealth { get; private set; }

    [Header("Damage amount dealt by ship contact")]
    [field:SerializeField]public int ShipDamagePoints { get; private set; }
    #endregion

    #region Exposed Scale Properties
    [Header("Smallest and Largest sizes")]
    [SerializeField] private float minAsteroidScale;
    [SerializeField] private float maxAsteroidScale;

    [Header("Scale cutoffs for small and medium asteroids")]
    [SerializeField] private float smallAsteroidScaleCutoff;
    [SerializeField] private float mediumAsteroidScaleCutoff; 
    #endregion

    #region Exposed Move Speed Properties
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
    #endregion

    #region Exposed Spin Speed Properties

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
    #endregion

    #region Exposed FX Properties
    [Header("AudioFX")]
    [field: SerializeField] public AudioClip TakeDamageFX { get; private set; }

    [Header("Destruction fx")]
    [field: SerializeField] public GameObject GreyRoidFx { get; private set; }
    [field: SerializeField] public GameObject BrownRoidFx { get; private set; } 
    #endregion

    //private cache of randomSpeed
    public float RandomSpinSpeed { get; private set; }

    #region Data Access API
    public Vector3 GetRandomScale()
    {
        //get the random scale
        float randomScaleValue = Random.Range(minAsteroidScale, maxAsteroidScale);

        //return the random scale
        return new Vector3(randomScaleValue, randomScaleValue, randomScaleValue);
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
    public int GetmaxHealthBasedOnScale(float randomScaleValue)
    {
        int maxHealth = 0;

        if (randomScaleValue < smallAsteroidScaleCutoff)
        {
            maxHealth = SmallAsteroidMaxHealth;
        }
        else if (randomScaleValue > smallAsteroidScaleCutoff || randomScaleValue < mediumAsteroidScaleCutoff)
        {
            maxHealth = MediumAsteroidMaxHealth;

        }
        else
        {
            maxHealth = LargeAsteroidMaxHealth;

        }

        return maxHealth;
    }
    public Sprite GetRandomGreySprite()
    {
        //set a random sprite
        int randomIndex = Random.Range(0, greyAsteroidSprites.Length);

        //select a random sprite using the index
        Sprite randomSprite = greyAsteroidSprites[randomIndex];

        return randomSprite;
    }
    public Sprite GetRandomBrownSprite()
    {
        //set a random sprite
        int randomIndex = Random.Range(0, brownAsteroidSprites.Length);

        //select a random sprite using the index
        Sprite randomSprite = brownAsteroidSprites[randomIndex];

        return randomSprite;
    }

    #endregion
}
