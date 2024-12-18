using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 lastCheckpointPosition = new Vector3(-3, -0, 1);
    public static bool isCheckpointSet = true; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            lastCheckpointPosition = transform.position;
            isCheckpointSet = true;

            Debug.Log("Checkpoint reached at: " + transform.position);
        }
    }
}