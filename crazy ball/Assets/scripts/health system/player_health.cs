using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    // for adding health bar
    public float MaxHealth;
    public float currentHealth;
    // public health_bar playerBar;
    // for adding health bar
    float timestamp = 0.0f;
    float interval = 60f;
    float health_up_count = 1f;
    private void Start()
    {
        
        MaxHealth = healths.playerHealth;
        currentHealth = healths.playerHealth;
        
    }
    private void Update() {
        if(Time.time>=timestamp){
            total_health_up();
        }
    }
    // player damage block
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "canon bullet")
        {
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            // playerBar.setHealth(currentHealth);//updating the fill of the health bar
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "mobile enemy bullet")
        {
            // playerBar.setHealth(currentHealth);//updating the fill of the health bar
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "projectile")
        {
            // playerBar.setHealth(currentHealth);//updating the fill of the health bar
            currentHealth -= other.gameObject.GetComponent<projectile>().projectileDamage;
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "boss1bullet")
        {
            // playerBar.setHealth(currentHealth);//updating the fill of the health bar
            currentHealth -= other.gameObject.GetComponent<bullet>().damage;
            // print(currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "missile1" || other.gameObject.tag == "missile2")
        {
            if (other.gameObject.tag == "missile1")
            {
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage1;
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    Destroy(gameObject);
                }
            }
            if (other.gameObject.tag == "missile2")
            {
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage2;
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    Destroy(gameObject);
                }
            }
        }
    }


    // player damage block

    // health up power up implementation
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "health up pill")
        {
            Debug.Log(currentHealth);
            if (currentHealth > 80)
            {
                float health_up = MaxHealth - currentHealth;
                currentHealth += health_up;
            }
            else if (currentHealth <= 80)
            {
                currentHealth += 20;
            }
            Debug.Log(currentHealth);
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().health_up_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject);
        }
    }
    // health up power up implementation
    void total_health_up(){
        healths.playerHealth += 10f * health_up_count;
        health_up_count += 0.5f;

    }
}
