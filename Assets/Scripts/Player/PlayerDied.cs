using UnityEngine;




public class PlayerDied : MonoBehaviour

{
    public AudioClip deathSound; 
    private AudioSource audioSource;


    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Die()
    {

        PlayDeathSound();
        Boss[] bosses = FindObjectsOfType<Boss>();
        foreach (Boss boss in bosses)
        {
            boss.ResetHealth();
        }



        LaunchSpike[] spikes = FindObjectsOfType<LaunchSpike>();
        foreach (LaunchSpike spike in spikes)
        {
            spike.ResetSpike();
        }





        if (Checkpoint.isCheckpointSet)
        {
            transform.position = Checkpoint.lastCheckpointPosition;
            
     
           

        }
        else
        {
            Debug.Log("No checkpoint set, player can't respawn.");
            
        }
    }

    private void PlayDeathSound()
    {
        if (deathSound != null && audioSource != null)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No death sound or AudioSource assigned.");
        }
    }
}
