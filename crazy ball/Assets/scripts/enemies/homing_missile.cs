using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb_missile;

    [SerializeField] private float rotate_speed = 200f;
    [SerializeField] private float speed = 5f;
    private void Start() {
        player = GameObject.Find("player");
        rb_missile = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 current_dir = transform.up;
        direction.Normalize();
        float rotate_amount = Vector3.Cross(direction, current_dir).z;

        rb_missile.angularVelocity = -rotate_amount*rotate_speed;
        rb_missile.velocity = transform.up * speed;
    }
}
