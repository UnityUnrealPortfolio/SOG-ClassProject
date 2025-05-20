using UnityEngine;

/// <summary>
/// This class holds the configuration data for asteroids
/// spawning into the world includin their many sprite variations,
/// and min and max speed variations as well as the pickup drop 
/// variations
/// </summary>
[CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Scriptable Objects/Asteroid/AsteroidConfig")]
public class AsteroidConfigSO : ScriptableObject
{
    #region Exposed Fields
    [Header("The different asteroid sprite variations")]
    [SerializeField] private Sprite[] asteroidSprites;

    [Header("The lowest and highest asteroid speed")]
    [Range(3, 5)]
    [SerializeField] private float minAsteroidSpeed;

    [Range(5, 10)]
    [SerializeField] private float maxAsteroidSpeed;

    [Header("The smallest and largest asteroid scale")]
    [Range(1, 2)]
    [SerializeField] private float minAsteroidScale;

    [Range(3, 5)]
    [SerializeField] private float maxAsteroidScale; 
    #endregion

    #region Data Access Utility
    public float GetRandomSpeed()
    {
        return Random.Range(minAsteroidSpeed, maxAsteroidSpeed);
    }

    public Sprite GetRandomSprite()
    {
        //get random index
        int randomIndex = Random.Range(0, asteroidSprites.Length);

        //get random sprite
        Sprite randomSprite = asteroidSprites[randomIndex];

        //return random sprite
        return randomSprite;
    }

    public Vector3 GetRandomScale()
    {
        float randomScale = Random.Range(minAsteroidScale, maxAsteroidScale);

        return new Vector3(randomScale, randomScale, randomScale);
    }
} 
#endregion
