using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public Transform playerPos;
    public Vector2 currentPos;
    public float distance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance) {
            StartCoroutine(RandomAction());
        } else {
            transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
        }
        // Debug.Log(Vector2.Distance(transform.position, playerPos.position));
    }

    IEnumerator RandomAction() {
        while (true) {
            int random = Random.Range(0, 10);

            if (random >= 0 && random <= 4) {
                yield return new WaitForSeconds(8);
                Debug.Log("Diam");
                anim.SetBool("isDefend", false);
                anim.SetBool("isRunning", false);
                
            } else if (random >= 5 && random <= 8) {
                yield return new WaitForSeconds(8);
                anim.SetBool("isRunning", true);
                Debug.Log("Kejar");
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            } else {
                yield return new WaitForSeconds(8);
                anim.SetBool("isDefend", true);
                Debug.Log("Serang");
            }
        }    
    }

    
        // private void OnCollisionEnter2D(Collision2D other) {
        //     if (other.gameObject.CompareTag("Player")) {
        //         var player = other.gameObject.GetComponent<PlayerLife>();
        //         player.Die();
        //     }    
        // }
}
