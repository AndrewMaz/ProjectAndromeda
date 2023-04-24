using UnityEngine;


public class Enemy : MonoBehaviour, ITeleportable
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float attackTime = 1f;

    protected float attackTimer;



    public bool IsDead { get; private set; }

    protected Rigidbody2D rb;
    protected Movement movement;
    protected MovementY movementY;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        movementY = GetComponent<MovementY>();
    }

    public void OnEnable()
    {
        IsDead = false;

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
        if (IsDead) return;

        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetTrigger("takeDamage");
        movement.Speed = movement.DeadSpeed;
        if (movementY != null)
        {
            movementY.enabled = false;
        }

        IsDead = true;
    }

    public virtual void Attack()
    {
        animator.SetTrigger("attack");
        attackTimer = attackTime;
    }
}
