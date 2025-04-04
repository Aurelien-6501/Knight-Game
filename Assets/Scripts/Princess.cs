using UnityEngine;

public class Princess : MonoBehaviour
{
    public int health = 200; // Points de vie de la princesse
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Réduire les points de vie par la valeur des dégâts reçus

        if (health <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        Debug.Log("Princess has died."); 
        _animator.SetTrigger("PrincessDead");
        Invoke("DisablePrincess", 10f); // Planifier la désactivation du GameObject

    }

    void DisablePrincess()
    {
        gameObject.SetActive(false); // Désactiver le GameObject
    }
}