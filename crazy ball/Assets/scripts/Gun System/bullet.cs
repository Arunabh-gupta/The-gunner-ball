using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.collider.tag == "obstacle"){
    //         Destroy(gameObject);
    //         Debug.Log(other);
    //     }
    // }

    private void Update() {
        Destroy(gameObject,3f);
    }
}
