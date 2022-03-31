using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private Rigidbody2D Boss1Rb; // access to rigidbody for adding angular velocity
    [SerializeField] private float revolvingSpeed; // angular velocity given to the circle

    [SerializeField] private GameObject bullet_prefab;

    // time delay between the bullets
    private float timestamp = 0.0f;
    [SerializeField] private float DelayPerShot;
    // time delay between the bullets

    [SerializeField] private float bullet_speed; // speed of the bullets

    // health system of the boss
    private float Currenthealth = healths.Boss1Health;
    private float Maxhealth = healths.Boss1Health;
    // health system of the boss

    [Header("death particle effect")]
    // death particle effect
    [SerializeField] private ParticleSystem death_effect;
    // death particle effect
    private void Start()
    {
        bullet_speed = Gun_Container.Boss1Gun.GetSpeed();
        DelayPerShot = Gun_Container.Boss1Gun.GetFireRate();
        Boss1Rb = GetComponent<Rigidbody2D>();

        Boss1Rb.angularVelocity = revolvingSpeed;

    }
    private void Update()
    {
        if (Time.time > timestamp)
        {
            BossGunFiring();
        }
    }
    // firing system of the guns in boss 1. Very similar to the every gun in the game
    void BossGunFiring()
    {
        timestamp = Time.time + DelayPerShot;
        foreach (Transform child in this.transform)
        {
            GameObject gunOnBoss = child.gameObject;
            Transform shootpoint = gunOnBoss.transform.GetChild(0).transform;
            Vector2 dir = (Vector2)shootpoint.position - (Vector2)gunOnBoss.transform.position;
            dir.Normalize();
            GameObject bullet = Instantiate(bullet_prefab, shootpoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bullet_speed;
        }
    }
    // firing system of the guns in boss 1. Very similar to the every gun in the game

    // Boss damage
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "player bullet")
    //     {
    //         Currenthealth -= other.gameObject.GetComponent<bullet>().damage;
    //         if (Currenthealth <= 0)
    //         {
    //             Destroy(gameObject);
    //         }
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player bullet")
        {
            Currenthealth -= other.gameObject.GetComponent<bullet>().damage;
            if (Currenthealth <= 0)
            {

                Destroy(gameObject);
                death_effect.Play();
            }
        }
    }
    // Boss damage
}
