using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 mass;
    [SerializeField] private Movement movement;
    [SerializeField] private Animator animator;

    void Update()
    {
        rb.centerOfMass = mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor _))
        {
            movement.enabled = true;
            rb.velocity = Vector2.zero;
        }
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            /*gameObject.transform.SetParent(enemy.transform);
            rb.bodyType = RigidbodyType2D.Kinematic;*/
        }
    }

    public void Deflect()
    {
        rb.velocity = new Vector2(-2, 1);
        movement.enabled = true;

        animator.SetTrigger("Deflected");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rb.worldCenterOfMass, 0.1f);
    }
}
