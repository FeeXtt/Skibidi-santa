using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public void Die()
    {
        // Hr�� zem�el, respawn na posledn� checkpoint
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
