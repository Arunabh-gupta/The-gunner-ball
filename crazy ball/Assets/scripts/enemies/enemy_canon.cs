using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_canon : MonoBehaviour
{
    [SerializeField]
    private GameObject target_player;
    [SerializeField]
    private Transform shootpoint;
    [SerializeField]
    private float looking_Radius = 3f;
    [SerializeField]
    private GameObject canon_bullet_prefab;
    [SerializeField]
    private float canon_bullet_speed = 10f;
    [SerializeField]
    private float canon_rotation_speed = 1.5f;
    //for time delay between each shot of bullet
    private float timestamp = 0.0f;
    private float DelayPerShot = 0.5f;
    //for time delay between each shot of bullet
    Vector2 target_dir;

    private void Update()
    {

        target_dir = target_player.transform.position - transform.position;
        if (target_dir.magnitude <= looking_Radius && Time.time > timestamp)
        {
            fire_cannon();
            Debug.Log(target_dir.magnitude);

        }

        lookAt();

    }

    // for the canon to look at the player 
    private void lookAt()
    {
        float target_angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, target_angle), canon_rotation_speed * Time.deltaTime);
    }
    // for the canon to look at the player 

    // for the canon to fire bullets
    private void fire_cannon()
    {
        timestamp = DelayPerShot + Time.time;
        GameObject canon_bullet = Instantiate(canon_bullet_prefab, (Vector2)shootpoint.position, Quaternion.identity);
        Vector2 canon_bullet_direction = target_dir;
        canon_bullet_direction.Normalize();
        canon_bullet.GetComponent<Rigidbody2D>().velocity = canon_bullet_direction * canon_bullet_speed;
    }
    // for the canon to fire bullets



}
