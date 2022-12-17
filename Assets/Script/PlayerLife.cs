using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public int maxHealth;
    private int currentHealth;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        
        DieFall();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("wave")){
            TakeDamage(100);    
        } else if (collision.gameObject.CompareTag("saw")){
            TakeDamage(100);
        } else if (collision.gameObject.CompareTag("Enemy")) {
            TakeDamage(20);
        } else if (collision.gameObject.CompareTag("Bos")) {
            var enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy.isAttack) {
                TakeDamage(25);
            } 
            
            if (enemy.isUltimate) {
                TakeDamage(100);
            }
        }
    }

    public void Die(){
        // rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        RestartLevel();
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DieFall() {
        if (rb.position.y <= -10) {
            RestartLevel();
        }
    }

    private void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) {
            Die(); 
            RestartLevel();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")){
            var enemy = other.gameObject.GetComponent<enemyPatrol>();
        }

        if (other.gameObject.CompareTag("Bos")){
            var enemy = other.gameObject.GetComponent<EnemyAI>();
        }
    }
    
}
