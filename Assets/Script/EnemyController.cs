using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // private float random;
    // private float timeRemaining = 10;
    // private bool isRunningTime = false;
    public Animator anim;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // isRunningTime = true;   
        StartCoroutine(RandomAction());

    }
    IEnumerator RandomAction() {
        while (true) {
            int random = Random.Range(0, 10);

            if (random >= 0 && random <= 4) {
                anim.SetBool("isFollow", false);
                anim.SetBool("isAttack", false);

                // Debug.Log("Diam");
            } else if (random >= 5 && random <= 8) {
                anim.SetBool("isFollow", true);
                anim.SetBool("isAttack", false);
                // Debug.Log("Kejar");
                
            } else {
                anim.SetBool("isAttack", true);
                anim.SetBool("isFollow", false);
                // Debug.Log("Serang");
            }
            yield return new WaitForSeconds(3);
        }
    }
    // Update is called once per frame
    // void Update()
    // {
    //     if (isRunningTime) {
    //         if (timeRemaining > 0) {
    //             timeRemaining -= Time.deltaTime;
    //         } else {
    //             Debug.Log("Time out");
    //             isRunningTime = false;
    //             random = Random.Range(0, 10);
    //             Debug.Log(random);
                
    //             if (random >= 0 && random <= 6) {
    //                 // Diam
    //             } else if (random >= 7 && random <= 9) {
    //                 // Kejar
    //             } else {
    //                 // Serang
    //             }
    //         }
    //     }
    // }
}
