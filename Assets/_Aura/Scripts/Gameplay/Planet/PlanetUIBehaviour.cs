using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This component gives feedback on the planet's health
/// </summary>
public class PlanetUIBehaviour : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;

    public void UpdatePlanetHealth(int health)
    {
        float healthValue = health / 100f;

        healthBarImage.fillAmount = healthValue;
    }
}
