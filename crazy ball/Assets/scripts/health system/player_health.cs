using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_health : MonoBehaviour
{
    // for adding health bar
    public float MaxHealth;
    public float currentHealth;
    public health_bar playerBar;
    // for adding health bar
    float timestamp = 0.0f;
    // float interval = 60f;
    // float health_up_count = 1f;
    bool player_alive = true;

    // to display end screen canvas
    // [SerializeField] CanvasGroup endscreen_canvas;
    [SerializeField]gameOverScreen gameoverscreen;
    private void Start()
    {

        MaxHealth = healths.playerHealth;
        currentHealth = healths.playerHealth;
        playerBar.SetMaxHealth(MaxHealth);

        // endscreen_canvas.GetComponent<CanvasGroup>().alpha = 0;
        

    }
    private void Update() {
        if(player_alive == false){
            print("player is dead");
            // endscreen_canvas.GetComponent<CanvasGroup>().alpha = 1;
            // endscreen_canvas.enabled = true;
            gameoverscreen.setup();
        }
    }

    // player damage block
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "canon bullet")
        {
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "mobile enemy bullet")
        {
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "projectile")
        {
            currentHealth -= other.gameObject.GetComponent<projectile>().projectileDamage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "boss1bullet")
        {
            currentHealth -= other.gameObject.GetComponent<bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            // print(currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "missile1" || other.gameObject.tag == "missile2")
        {
            if (other.gameObject.tag == "missile1")
            {
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage1;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    player_alive = false;
                    Destroy(gameObject, 0.1f);
                }
            }
            if (other.gameObject.tag == "missile2")
            {
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage2;
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
                print("player currenthealth: " + currentHealth);
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    player_alive = false;
                    Destroy(gameObject, 0.1f);
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
            // Debug.Log(currentHealth);
            if (currentHealth > 80 && currentHealth < MaxHealth)
            {
                float health_up = MaxHealth - currentHealth;
                currentHealth += health_up;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
            }
            else if (currentHealth <= 80)
            {
                currentHealth += 20;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
            }
            Debug.Log(currentHealth);
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().health_up_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject);
        }
    }
    // health up power up implementation
}
