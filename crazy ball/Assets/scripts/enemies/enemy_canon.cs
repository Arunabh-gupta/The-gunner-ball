using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemy_canon : MonoBehaviour
{

    // for adding health bar
    [SerializeField] private float MaxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private health_bar canonBar;
    // for adding health bar

    // for popping text animation
    [SerializeField] GameObject damage_indicator;
    
    
    // for popping text animation
    private GameObject target_player;
    [SerializeField]
    private Transform shootpoint;
    [SerializeField]
    private float looking_Radius = 10f;
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

    // death particle effects
    [Header("death particle effect")]
    [SerializeField] private ParticleSystem death_effect;

    // death particle effects
    private void Start()
    {
        // for adding health bar
        currentHealth = healths.canonHealth;
        MaxHealth = healths.canonHealth;
        canonBar.SetMaxHealth(MaxHealth);
        // for adding health bar

        target_player = GameObject.FindGameObjectWithTag("Player");// At the start of the game it would assign Player gameobject directly to the target_player so that i don't have to that manually

        // using gun_container class to assign the gun features
        canon_bullet_speed = Gun_Container.canon.GetSpeed();
        DelayPerShot = Gun_Container.canon.GetFireRate();
        // using gun_container class to assign the gun features

        // for popping text animation
        
        // for popping text animation        
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


    // health damage for the canon
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player bullet")
        {
            currentHealth -= other.gameObject.GetComponent<bullet>().damage;
            
            // canonBar.setHealth(currentHealth); //updating the fill of the health bar
            // POPUPtextGenerator.POPuptext(other.gameObject.GetComponent<bullet>().damage.ToString(), gameObject, damage_indicator);
            
            Debug.Log(death_effect.transform.position);
            if (currentHealth <= 0)
            {
                // death_effect.Play();
                Destroy(gameObject);
            }
        }
    }
    // health damage for the canon

}
