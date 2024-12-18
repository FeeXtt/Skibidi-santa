using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] candy;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (candy != null && candy.Length > 0 && firePoint != null)
        {
            anim.SetTrigger("attack");
            cooldownTimer = 0;

            candy[FindCandy()].transform.position = firePoint.position;
            candy[FindCandy()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        else
        {
            Debug.LogWarning("FirePoint or Candy is not assigned!");
        }

        
    }
    private int FindCandy()
    {
        for (int i = 0; i < candy.Length; i++)
        {
            if (!candy[i].activeInHierarchy)
            {
                return i;
            }
            
        }
        return 0;
    }
}