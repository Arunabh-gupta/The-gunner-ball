using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon_bullet : MonoBehaviour
{
    
    public float damage;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "obstacle"){
            Destroy(gameObject);
            
        }
       
            
    }

    private void Update() {
        Destroy(gameObject,3f);
    }
}
