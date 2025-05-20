using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] float laserSpeed = 5f;

    private void Update()
    {
        MoveLaser();
    }
    void MoveLaser()
    {
        transform.Translate(laserSpeed * Time.deltaTime * Vector2.up);
    }
}
