using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public void Die()
    {
        // Hráè zemøel, respawn na poslední checkpoint
        if (Checkpoint.isCheckpointSet)
        {
            transform.position = Checkpoint.lastCheckpointPosition;
        }
        else
        {
            Debug.Log("No checkpoint set, player can't respawn.");
        }
    }
}
