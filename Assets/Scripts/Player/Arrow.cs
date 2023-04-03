using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 mass;
    [SerializeField] private Movement movement;

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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rb.worldCenterOfMass, 0.1f);
    }
}
