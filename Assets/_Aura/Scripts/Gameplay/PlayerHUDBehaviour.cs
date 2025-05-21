using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This component handles displaying updates to player's
/// data
/// 
/// </summary>
public class PlayerHUDBehaviour : MonoBehaviour
{
    [SerializeField] private Image shipHealthBar;
    [SerializeField] private Image shipShieldBar;
    [SerializeField] private Image[] shipLivesIcons;
    [SerializeField] private Color lostLivesTint;
    [SerializeField] private Color normalLivesTint;

    private PlayerShipHealth playerShipHealth;

    #region Mono Core Loop Callbacks
    private void Awake()
    {
        playerShipHealth = FindFirstObjectByType<PlayerShipHealth>();
    }
    private void OnEnable()
    {
        if (playerShipHealth != null)
        {
            playerShipHealth.OnShipHealthUpdate += HandleShipHealthUpdate;
            playerShipHealth.OnPlayerLivesUpdate += HandleShipLivesUpdate;
        }

    }
    private void OnDisable()
    {
        if (playerShipHealth != null)
        {
            playerShipHealth.OnShipHealthUpdate -= HandleShipHealthUpdate;
            playerShipHealth.OnPlayerLivesUpdate -= HandleShipLivesUpdate;
        }
    }
    #endregion

    #region Event Handlers
    private void HandleShipLivesUpdate(int livesValue)
    {
        //turn off all icons
        foreach (var icon in shipLivesIcons)
        {
            icon.color = lostLivesTint;
        }

        //turn on icons according to livesValue
        for (var i = 0; i < livesValue; i++)
        {
            shipLivesIcons[i].color = normalLivesTint;
        }
    }

    private void HandleShipHealthUpdate(float healthValue)
    {
       shipHealthBar.fillAmount = healthValue;
    }
    #endregion
}
