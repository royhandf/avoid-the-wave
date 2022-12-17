using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkSpeed;
    private bool flip;
    private Animator anim;
    private BoxCollider2D[] boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        flip = true;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flip) {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Flip")) {
            flip = !flip;
        }
    }
}
