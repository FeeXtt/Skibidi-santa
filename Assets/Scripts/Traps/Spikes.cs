using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            
            collision.collider.GetComponent<PlayerDied>().Die();
        }
    }
}