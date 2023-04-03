using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class Enemy : MonoBehaviour, ITeleportable
{
    [SerializeField] private Animator animator;
    [SerializeField] float attackTime = 1f;

    private float attackTimer;

    Rigidbody2D rb;
    Movement movement;
    MovementY movementY;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        movementY = GetComponent<MovementY>();
    }

    public void OnEnable()
    {
        if (movementY != null)
        {
            movementY.enabled = true;
        }

        movement.Speed = movement.MovementSpeed;
        rb.bodyType = RigidbodyType2D.Kinematic;
        attackTimer = attackTime;
    }

    public void FixedUpdate()
    {
        attackTimer -= Time.fixedDeltaTime;
        if (attackTimer < 0f)
            Attack();
    }

    public virtual void Teleport()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor _))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    public virtual void Die()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetTrigger("takeDamage");
        movement.Speed = movement.DeadSpeed;
        if (movementY != null)
        {
            movementY.enabled = false;
        }
    }

    public virtual void Attack()
    {
        animator.SetTrigger("attack");
        attackTimer = attackTime;
    }
}
