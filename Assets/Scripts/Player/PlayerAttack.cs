using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] candy;
    [SerializeField] private AudioClip attackSound;
    private AudioSource audioSource;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {

        
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

            PlayAttackSound();
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

    private void PlayAttackSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound); 
        }
        else
        {
            Debug.LogWarning("No attack sound assigned!");
        }
    }
}