using UnityEngine;

public class BossProjectile : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public float lifetime = 5f;

    private void OnEnable()
    {
        Invoke("Deactivate", lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate"); 
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            collision.GetComponent<PlayerDied>().Die();
            gameObject.SetActive(false);
            


        }
    }
}