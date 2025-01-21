using UnityEngine;

public class LaunchSpike : MonoBehaviour
{
    public float riseSpeed = 10;
    public Vector2 direction;
    public bool isRising = false;
    public bool isHidden = false;
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D spikeCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = rb.position;
        spikeCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
        if (isRising)
        {
            LaunchTheSpike();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<SimpleMovement>() && !isRising && !isHidden)
        {
            isRising = true;
        }
    }

    private void LaunchTheSpike()
    {
        
        Vector2 newPosition = rb.position + direction.normalized * riseSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.GetComponent<SimpleMovement>() && !isHidden)
        {
            collision.collider.GetComponent<PlayerDied>().Die();
            ResetSpike();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other is PolygonCollider2D && !other.GetComponent<SimpleMovement>())
        {
            HideSpike();
        }
    }

    private void HideSpike()
    {
        Debug.Log("Spike hidden!");
        spriteRenderer.enabled = false;
        spikeCollider.enabled = false;
        isRising = false;
        isHidden = true;
    }

    public void ResetSpike()
    {
        
        rb.position = initialPosition;
        isRising = false;
        isHidden = false;
        spriteRenderer.enabled = true;
        spikeCollider.enabled = true;
    }
}