using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    private Camera cam;

    public float magnitude;
    
    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(magnitude));
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(magnitude));
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
