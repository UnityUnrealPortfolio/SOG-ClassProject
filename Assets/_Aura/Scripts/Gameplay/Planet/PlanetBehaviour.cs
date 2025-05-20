using System;
using UnityEngine;


/// <summary>
/// This component defines the base behaviour of the planet
/// which is to take damage when hit by asteroids, relay that damage
/// to the UI and get destroyed when health drops to below zero.
/// </summary>
public class PlanetBehaviour : MonoBehaviour
{
    #region Exposed Fields
    [Header("Health properties")]
    [SerializeField] private int maxHealth;

    [Header("Planet Health UI")]
    [SerializeField] private PlanetUIBehaviour planetUI;
    #endregion

    #region Properties and Backing Fields

    private int currentHealth;
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;

            if (currentHealth <= 0)
            {
                //handle planet destruction
                HandleDestruction();
            }

            planetUI.UpdatePlanetHealth(currentHealth);
        }
    }
    #endregion

    #region Mono Core Loop Callbacks
    private void Start()
    {
        CurrentHealth = maxHealth;
    } 
    #endregion

    #region Mono Physics Callbacks
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("asteroid"))
        {
            
            //ToDo:may have different size asteroids do more damage
            TakeDamage();
        }
    } 
    #endregion

    #region Damage and Destruction Utility
    private void TakeDamage()
    {
        //play cam shake animation

        //reduce current health
        CurrentHealth -= 10;
    }

    private void HandleDestruction()
    {
        //play explosion fx
        //play explosion audio
        //inform game manager
        //destroy planet
        Destroy(gameObject);
    } 
    #endregion
}
