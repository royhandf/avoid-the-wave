using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour {
    public float FollowSpeed = 2f;
    public float yOffSet = 1f;
    public float xOffSet = 1f;
    public Transform target;

    void Update() {
        Vector3 newPos = new Vector3(target.position.x + xOffSet, target.position.y + yOffSet , -5f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}