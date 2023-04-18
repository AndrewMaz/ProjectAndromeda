using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float damageCooldown = 1f;

    float timer;

    private void Start()
    {
        timer = damageCooldown;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && timer < 0f)
        {
            player.TakeDamage(damage);

            timer = damageCooldown;
        }
        if (collision.gameObject.TryGetComponent(out Arrow arrow))
        {
            arrow.Deflect();
        }
    }
}
