using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_canon : MonoBehaviour
{

    [SerializeField]
    private float health = healths.canonHealth;
    [SerializeField]
    private GameObject target_player;
    [SerializeField]
    private Transform shootpoint;
    [SerializeField]
    private float looking_Radius = 3f;
    [SerializeField]
    private GameObject canon_bullet_prefab;
    [SerializeField]
    private float canon_bullet_speed;
    [SerializeField]
    private float canon_rotation_speed = 250f;
    //for time delay between each shot of bullet
    private float timestamp = 0.0f;
    private float DelayPerShot;
    //for time delay between each shot of bullet
    Vector2 target_dir;

    // private void Start() {
    //     target_player = GameObject.FindGameObjectWithTag("Player");

    // }
    private void Start() {
        canon_bullet_speed = Gun_Container.canon.GetSpeed();
        DelayPerShot = Gun_Container.canon.GetFireRate();
    }
    private void Update()
    {

        target_dir = target_player.transform.position - transform.position;
        if (target_dir.magnitude <= looking_Radius && Time.time > timestamp)
        {
            fire_cannon();
            
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
        canon_bullet.GetComponent<canon_bullet>().damage = Gun_Container.canon.GetDamage();
        Vector2 canon_bullet_direction = target_dir;
        canon_bullet_direction.Normalize();
        canon_bullet.GetComponent<Rigidbody2D>().velocity = canon_bullet_direction * canon_bullet_speed;
    }
    // for the canon to fire bullets



    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "player bullet"){
            health-=other.gameObject.GetComponent<bullet>().damage;
            Debug.Log("canon's health "+health);
            if(health<=0){
                Destroy(gameObject);
            }
        }
    }

}
