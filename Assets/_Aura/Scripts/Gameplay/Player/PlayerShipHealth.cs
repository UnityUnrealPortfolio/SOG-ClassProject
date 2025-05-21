using System;
using UnityEngine;

/// <summary>
/// This component, manages the ship's health,
/// responding to both damage and health pickups
/// it relays info about ship's to subscribers
/// via an event
/// </summary>
public class PlayerShipHealth : MonoBehaviour
{
    [Header("Ref to Collision Detection")]
    [SerializeField] private CollisionDetectionBehaviour collisionDetection;

    [Header("Ship Health properties")]
    [SerializeField] private int maxShipHealth = 100;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int asteroidCollisionDamagePoints;

    //event to notify of current ship health
    public event Action<float> OnShipHealthUpdate;

    //event to notify of current ship lives
    public event Action<int> OnPlayerLivesUpdate;

    #region Properties
    private float currentHealth;
    private float CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;

            if (currentHealth > maxShipHealth)
            {
                currentHealth = maxShipHealth;
            }
            else if (currentHealth < 0)
            {
                //reduce lives by one if any left
                if (CurrentLives > 0)
                {
                    CurrentLives--;
                    currentHealth = maxShipHealth;
                }
                else
                {
                    Debug.Log("Ship Destroyed!");
                }

            }

            OnShipHealthUpdate?.Invoke(currentHealth / maxShipHealth);
        }

    }

    private int currentLives;
    private int CurrentLives
    {
        get => currentLives;
        set
        {
            currentLives = value;

            if (currentLives < 0)
            {
                //no more lives!
            }

            OnPlayerLivesUpdate?.Invoke(currentLives);
        }
    }
    #endregion

    #region Mono Core Loop Callbacks
    private void Awake()
    {
        collisionDetection = GetComponentInChildren<CollisionDetectionBehaviour>();
    }
    private void OnEnable()
    {
        //subscribe to listen to collision pickup events
        if (collisionDetection is not null)
        {
            collisionDetection.OnAsteroidCollision += HandleAsteroidCollision;
        }
        else
        {
            return;
        }
    }

    private void Start()
    {
        //Initialize health properties
        CurrentHealth = maxShipHealth;
        CurrentLives = maxLives;
    }
    private void OnDisable()
    {
        //unsubscribe from collision pickup events
        if(collisionDetection is not null)
        {
            collisionDetection.OnAsteroidCollision += HandleAsteroidCollision;
        }
        else
        {
            return;
        }
    }
    private void HandleAsteroidCollision()
    {
        CurrentHealth -= asteroidCollisionDamagePoints;
    }
    #endregion
}
