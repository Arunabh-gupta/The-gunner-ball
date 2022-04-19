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


    private void Start()
    {
        // for adding health bar
        // playerBar = GameObject.Find("health bar").GetComponent<health_bar>();
        MaxHealth = healths.playerHealth;
        currentHealth = healths.playerHealth;
        // playerBar.SetMaxHealth(MaxHealth);
        // for adding health bar
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
    }


    // player damage block

    // health up power up implementation
    private void OnTriggerEnter2D(Collider2D other) {
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
            Destroy(other.gameObject);
        }
    }
    // health up power up implementation

}
