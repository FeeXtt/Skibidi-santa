using UnityEngine;

public class SoundTrack : MonoBehaviour
{
    public static SoundTrack instance;
    public AudioClip backgroundMusic; 
    private AudioSource audioSource; 

    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

       
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.volume = 0.5f; 
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No background music assigned!");
        }
    }

    
    public void ChangeMusic(AudioClip newMusic)
    {
        if (audioSource != null && newMusic != null)
        {
            audioSource.Stop();
            audioSource.clip = newMusic;
            audioSource.Play();
        }
    }
}