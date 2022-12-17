using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public bool flip;
    public float speed;
    public SpriteRenderer sr;
    // public int distance;
    private Animator anim;
    private Transform playerPos;
    private Vector2 currentPos;
    // private bool isAction;
    // private float timeRemaining = 1;
    private int maxHealth = 3;
    public int currentHealth;   
    
    public bool isDefend = false;
    public bool isAttack = false;
    public bool isUltimate = false;

    void Start() {
        anim = GetComponent<Animator>();
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        // isAction = true;

        currentHealth = maxHealth; 
        StartCoroutine(RandomAction());
    }

    void Update() {
        if (player.transform.position.x > transform.position.x) {
            sr.flipX = false;
        } else {
            sr.flipX = true;
        }

        if (Vector2.Distance(transform.position, playerPos.position) < 6) {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
                anim.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (speed + 1) * Time.deltaTime);
            } else {
                anim.SetBool("isRunning", false);
            }
        } else {
            // anim.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
            
            anim.SetBool("isRunning", false);
        }

    }

    IEnumerator RandomAction() {
        while (true) {
            yield return new WaitForSeconds(3);
            int random = Random.Range(0, 10);

            if (random >= 0 && random <= 4) {
                anim.SetInteger("SkillIndex", 0);
                anim.SetTrigger("Skill");
                isDefend = true;
    
            } else if (random >= 5 && random <= 9) {
                anim.SetInteger("SkillIndex", 1);
                anim.SetTrigger("Skill");
                isAttack = true;

            } else {
                anim.SetInteger("SkillIndex", 2);
                anim.SetTrigger("Skill");
                isUltimate = true;
            }
        }
    }

    public void TakeDamage(int damage) {
        if (isDefend) {
            currentHealth -= damage;
        } else {
            isDefend = false;
        }
        
        if (currentHealth <= 0) {
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 1f);
        }
    }
}
