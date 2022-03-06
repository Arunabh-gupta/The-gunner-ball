using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_aim : MonoBehaviour
{
    

    //for gun aim
    Vector2 dir_vector;
    private float target_angle;
    Rigidbody2D gun_rb;
    [SerializeField]
    private float time = 100f;
    // gun aim
    void Start()
    {
        gun_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //gun aim rotation
        dir_vector = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_angle = (Mathf.Atan2(dir_vector.x, -dir_vector.y) + Mathf.PI / 2) * Mathf.Rad2Deg;
        gun_rb.MoveRotation(Mathf.LerpAngle(gun_rb.rotation, target_angle, Time.deltaTime * time));
        //gun aim rotation
    }
}
