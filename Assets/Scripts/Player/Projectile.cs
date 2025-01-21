using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5.1f;
    private float direction;
    private bool hit;

    private BoxCollider2D boxCollider;
    private Animator anim;

    [SerializeField] private float timeToLive = 5f;
    private float timeAlive;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        timeAlive = 0f;
    }

    private void Update()
    {
        if (hit) return;

        
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToLive)
        {
            Deactivate();
            return;
        }

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NoCollisionObjec")) return;

        if (other.CompareTag("Boss"))
        {
            Boss boss = other.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(1); 
            }
        }

        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

