
// Spike.cs - Skript pro hroty
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<SimpleMovement>())
        {
            collision.collider.GetComponent<PlayerDied>().Die();
        }
    }
}
