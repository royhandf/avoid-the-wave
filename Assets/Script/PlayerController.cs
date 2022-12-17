using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform idle_player;
    public Rigidbody2D rb;
    public float walkspeed, jumpForce;
    public SpriteRenderer sr;
    public Animator anim;

    private bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && !isjumping)
       {
            rb.AddForce(transform.up * jumpForce);
            isjumping = true;
            anim.SetBool("isJump", true);
       }
       else if (!Input.GetKeyDown(KeyCode.Space) && isjumping)
       {
            anim.SetBool("isJump", false);
       }

       if (Input.GetKey(KeyCode.D)){
            // Debug.Log("Maju");
        
            float z = idle_player.position.z;
            float y = idle_player.position.y;
            float x = idle_player.position.x+speed;

            idle_player.position = new Vector3(x,y,z);
            sr.flipX = false;
            anim.SetBool("isRunning", true);
        }

        else if (Input.GetKey(KeyCode.A)){
            // Debug.Log("Mundur");
        
            float z = idle_player.position.z;
            float y = idle_player.position.y;
            float x = idle_player.position.x-speed;

            idle_player.position = new Vector3(x,y,z);
            sr.flipX = true;
            anim.SetBool("isRunning", true);
        }

        else if (!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A)){
            // Debug.Log("Diam");
            anim.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            isjumping = false;
        }
    }
}