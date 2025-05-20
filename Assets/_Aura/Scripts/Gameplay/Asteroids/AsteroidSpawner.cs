using UnityEngine;

/// <summary>
/// define a class that starts to spawn asteroids from the top of the screen
/// at random positions in the x axis. starts spawning some time after game starts.
/// spawning continues indefinitely.
/// rate of spawning can be determined dynamically and controlled from the game manager.
/// game manager should be able to stop the spawning and restart it.
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    #region Exposed Fields
    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private float leftSpawnExtent = -4.5f;
    [SerializeField] private float rightSpawnExtent = 4.5f; 
    #endregion

    #region Mono Core Loop Callbacks
    private void Start()
    {
        //wait some time
        //then start spawning
        InvokeRepeating("SpawnRandomAsteroid", 2f, 1f);
    }
    #endregion

    #region Spawn Utility
    private void SpawnRandomAsteroid()
    {

        //getting random x position
        float randomXPosition = Random.Range(leftSpawnExtent, rightSpawnExtent);

        //spawn in to the scene
        Instantiate(asteroidPrefab, new Vector2(randomXPosition, transform.position.y), Quaternion.identity);
    } 
    #endregion
}
