using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Camera cam;

    public float magnitude;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "obstacle")
        {
            Destroy(gameObject);
            // Debug.Log(other);
        }
        StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(magnitude));

    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }
}
