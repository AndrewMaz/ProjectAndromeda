using Unity.VisualScripting;
using UnityEngine;


public class FlyingEnemy : Enemy
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private float startHeight;

    private new void OnEnable()
    {
        if (projectile !=null)
        {
            projectile.gameObject.SetActive(true);
        }
        transform.position = new Vector3(transform.position.x, startHeight + Random.Range(-0.5f, 0.5f));
        base.OnEnable();
    }

    public override void Teleport()
    {
        base.Teleport();
    }

    public override void Die()
    {
        if (projectile != null)
        {
            projectile.gameObject.SetActive(false);
        }
        base.Die();
    }

    public override void Attack()
    {
        if (projectile != null && Random.Range(0f, 1f) > 0.35f)
        {
            projectile.IsFiring = true;
        }

        base.Attack();
    }
}