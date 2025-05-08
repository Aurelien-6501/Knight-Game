using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioClip menuTheme;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = menuTheme;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }

    
}