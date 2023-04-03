using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    Animator animator;
    CapsuleCollider2D capsuleCollider;
    Rigidbody2D rb;

    Vector2 startPosition;

    public Vector2 StartPosition { get { return startPosition; } }
    public bool IsFiring { get; set; }

    private void Awake()
    {
        startPosition = transform.localPosition;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Respawn();
    }

    private void Update()
    {
        if (!IsFiring) return;

        capsuleCollider.enabled = true;
        transform.localPosition += Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && IsFiring)
        {
            player.TakeDamage(damage);
        }
/*        else if (collision.gameObject.TryGetComponent(out Arrow arrow) && IsFiring)
        {
            arrow.Deflect();      
        }*/
        else if (collision.gameObject.TryGetComponent(out Floor _) && IsFiring)
        {
            Respawn();
            return;
        }
        else if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }

        capsuleCollider.enabled = false;
        animator.SetTrigger("deflected");
        rb.bodyType = RigidbodyType2D.Dynamic;
        IsFiring = false;
    }

    private void Respawn()
    {
        transform.localPosition = startPosition;
        rb.bodyType = RigidbodyType2D.Kinematic;
        IsFiring = false;
    }
}
