using Unity.VisualScripting;
using UnityEngine;


public class FlyingEnemy : Enemy
{
    [SerializeField] float damage = 10f;
    [SerializeField] private Projectile projectile;
    [SerializeField] private float startHeight;
    [SerializeField] private BoxCollider2D killColider;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (killColider == null) return;

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(damage);
        }
    }
}