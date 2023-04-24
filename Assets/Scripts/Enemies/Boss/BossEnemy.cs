using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] int health = 5;

    public new void Awake()
    {

    }

    public new void OnEnable()
    {
        attackTimer = attackTime;
    }

    public override void Die()
    {
        health--;
        animator.SetTrigger("takeDamage");
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Attack()
    {
        int randomTrigger = Random.Range(1, 3);

        animator.SetTrigger("attack" + randomTrigger);
        attackTimer = attackTime;
    }
}
