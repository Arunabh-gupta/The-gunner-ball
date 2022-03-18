using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
   public float health = healths.playerHealth;

   private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "canon bullet"){
           health-=other.gameObject.GetComponent<canon_bullet>().damage;
           if(health<=0){
               Destroy(gameObject);
           }
       }
       if(other.gameObject.tag == "mobile enemy bullet"){
           health-=other.gameObject.GetComponent<canon_bullet>().damage;
           if(health<=0){
               Destroy(gameObject);
           }
       }
   }

}
