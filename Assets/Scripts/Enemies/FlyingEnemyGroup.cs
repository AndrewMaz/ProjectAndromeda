using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyGroup : Enemy
{
    [SerializeField] private float startHeight;
    [SerializeField] private Animator[] additionalAnimators;

    private new void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, startHeight + Random.Range(-0.5f, 0.5f));
        base.OnEnable();
    }

    public override void Teleport()
    {
        base.Teleport();
    }

    public override void Die()
    {
/*        foreach (var animator in additionalAnimators) 
        {
            animator.SetTrigger("takeDamage");
        }*/

        base.Die();
    }

    public override void Attack()
    {
        base.Attack();
    }
}
