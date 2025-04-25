using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    public float speed = 5f;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float lastAttackTime = 0f;
    public float attackCooldown = 1.0f; // durée minimum entre chaque attaque en secondes

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(horizontal, vertical);

        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Velocity", _movement.sqrMagnitude);

        if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastAttackTime + attackCooldown)
        {
            _animator.SetTrigger("Attack");
            lastAttackTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _movement * speed;
    }

    void Hit()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1.0f, _movement.normalized, 1.0f);
        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("skeleton"))
            {
                hit.collider.gameObject.GetComponent<Skeleton>().TakeDamage(20);
            }
        }
    }
}