using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
public class WeaponConfigSO : ScriptableObject
{
    public GameObject laserPrefab;
    public float coolDownTime = 2f;
    public AudioClip fireSoundFx;
    public ParticleSystem fireParticleFx;
}
