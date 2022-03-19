using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    // for adding health bar
   public float MaxHealth;
   public float currentHealth;
   public health_bar playerBar;
    // for adding health bar
   private void Start() {
    // for adding health bar
       MaxHealth = healths.playerHealth;
       currentHealth = healths.playerHealth;
       playerBar.SetMaxHealth(MaxHealth);
    // for adding health bar
   }

   // player damage block
   private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "canon bullet"){
           currentHealth-=other.gameObject.GetComponent<canon_bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
           if(currentHealth<=0){
               Destroy(gameObject);
           }
       }
       if(other.gameObject.tag == "mobile enemy bullet"){
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
           currentHealth-=other.gameObject.GetComponent<canon_bullet>().damage;
           if(currentHealth<=0){
               Destroy(gameObject);
           }
       }
   }
   // player damage block

}
