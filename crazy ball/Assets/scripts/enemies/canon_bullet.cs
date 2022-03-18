using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon_bullet : MonoBehaviour
{
    // private Camera cam;
    // private void Start() {
    //     cam = FindObjectOfType<Camera>();
    // }
    public float damage;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "obstacle"){
            Destroy(gameObject);
            // Debug.Log(other);
        }
        // StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(0.15f, 0.45f));
            
    }

    private void Update() {
        Destroy(gameObject,3f);
    }
}
