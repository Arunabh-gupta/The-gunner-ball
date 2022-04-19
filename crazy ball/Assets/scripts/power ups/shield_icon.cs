using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_icon : MonoBehaviour
{
    [SerializeField] GameObject shield_powerup;
    
    
    private void Start() {
        // shield_powerup = GameObject.Find("shield");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            // shield_powerup.SetActive(true);
            GameObject force_sheild = Instantiate(shield_powerup, other.transform.position, Quaternion.identity);
            LeanTween.scale(force_sheild, new Vector3(1.2f, 1.2f, 0f), 1f).setEaseOutElastic(); // elastic popping shield animation
            LeanTween.rotateAround(force_sheild,Vector3.forward,-3600, 10f).setLoopClamp(); // rotation animation

            Destroy(gameObject);
        }
    }

    
}
