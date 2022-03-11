using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_aim : MonoBehaviour
{


    //for gun aim
    [HideInInspector]
    public Vector2 dir_vector;
    private float target_angle;
    Rigidbody2D gun_rb;
    [SerializeField]
    private float time = 100f;
    // gun aim
    void Start()
    {
        gun_rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (Vector2)transform.position - mousePos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+180));

    }




}
