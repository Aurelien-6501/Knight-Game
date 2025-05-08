using UnityEngine;

public class Princess : MonoBehaviour
{
    public int health = 200; 
    private Animator _animator;
    public PrincessHealthUI healthUI;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        healthUI.SetHearts(health / 20); // ex: 100 HP = 5 cœurs
    }

    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthUI.SetHearts(health / 20);

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Princess has died.");
        _animator.SetTrigger("PrincessDead");
        Invoke("DisablePrincess", 10f);
        GameManager.Instance.GameOver(); 
    } 
    void DisablePrincess()
    {
        gameObject.SetActive(false);
    }
}