// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NpcLife : MonoBehaviour
// {
//     private Rigidbody2D rb;
//     private Animator anim;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();  
//     }

//     // Update is called once per frame
//    private void OnCollisionEnter2D(Collision2D collision){
//     if (collision.gameObject.CompareTag("Ground")){
//         Die();
//     }
//    }

//    private void Die(){
//     rb.bodyType =RigidbodyType2D.Static;
//     anim.SetTrigger("death");
//    }

//    private void RestartLevel(){
//     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }
// }
