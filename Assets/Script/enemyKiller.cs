using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKiller : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }

        if (other.gameObject.CompareTag("Bos")) {
            var enemy = other.gameObject.GetComponent<EnemyAI>();
            enemy.TakeDamage(1);

            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }
}
