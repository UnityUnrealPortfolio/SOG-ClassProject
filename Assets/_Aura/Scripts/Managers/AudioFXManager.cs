using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFXManager : MonoBehaviour
{
    //reference to audio source component on this game object
     private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioFx(AudioClip audioFx)
    {
        audioSource.PlayOneShot(audioFx);
    }



}
