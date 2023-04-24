using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(damage);
        }
        if (collision.gameObject.TryGetComponent(out Arrow _) && gameObject.TryGetComponent(out Animator _))
        {
            animator.SetTrigger("destroy");
            collision.gameObject.SetActive(false);
        }
    }
}
