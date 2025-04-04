using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;
    public int health = 60;
    public int attackDamage = 20;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool isDead = false; // Variable pour contrôler l'état de mort

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; // Arrêter toute exécution si le squelette est mort

        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("skeleton_animation_attack"))
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > 0.5f)
            {
                _rigidbody2D.linearVelocity = direction * speed;
                _animator.SetBool("IsWalking", true);
                GetComponent<SpriteRenderer>().flipX = direction.x < 0;
            }
            else
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                _animator.SetBool("IsWalking", false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Ne pas prendre de dégâts si déjà mort

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // Marquer le squelette comme mort
        _animator.SetTrigger("IsDead");
        _rigidbody2D.linearVelocity = Vector2.zero; 
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic; 
        _animator.SetBool("IsWalking", false);
        _animator.SetBool("IsAttacking", false);
    
        foreach (var collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    
        Invoke("DisableSkeleton", 10f); // Planifier la désactivation du GameObject
    }
    
    void DisableSkeleton()
    {
        gameObject.SetActive(false); // Désactiver le GameObject
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead || !other.CompareTag("princess")) return;

        _rigidbody2D.linearVelocity = Vector2.zero;
        _animator.SetBool("IsWalking", false);
        _animator.SetTrigger("IsAttacking");
    }

    public void Damage()
    {
        if (isDead) return; // Ne pas attaquer si mort
        Debug.Log("Attack!");
        if (target.CompareTag("princess"))
        {
            Princess princess = target.GetComponent<Princess>();
            if (princess != null)
            {
                princess.TakeDamage(attackDamage);
            }
        }
    }
}