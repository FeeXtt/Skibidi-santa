using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;  
    [SerializeField] private GameObject[] projectilePool;
    public Transform shootPoint;
    public float shootInterval = 2f;
    public float detectionRange = 10f; 

    public int maxHealth = 20; 
    private int currentHealth; 

    private int currentWaypointIndex = 0; 
    private Transform player;
    private float shootTimer = 0f; 
    private int currentProjectileIndex = 0; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        currentHealth = maxHealth;
        
        foreach (var proj in projectilePool)
        {
            proj.SetActive(false);
        }
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (waypoints.Length == 0) return;

        
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void Shoot()
    {
        if (player == null) return;

        
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                
                GameObject projectile = projectilePool[currentProjectileIndex];
                projectile.transform.position = shootPoint.position;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);

               
                Vector2 direction = (player.position - shootPoint.position).normalized;
                projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f;

                
                currentProjectileIndex = (currentProjectileIndex + 1) % projectilePool.Length;

                shootTimer = 0f;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        Debug.Log($"Boss hit! Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }

    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        Debug.Log("Boss health reset to max.");
    }

    private void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject);
    }

}