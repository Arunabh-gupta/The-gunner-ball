using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missle_spawner : MonoBehaviour
{
    [SerializeField] GameObject[] missiles;
    private float xmin = -2f, xmax = 2f, ymin = -2f, ymax = 2f;

    // delay between 2 spawns;
    private float timeStamp = 0f;
    private float delay = 5f;
    Vector2 coordinate;

    private float total_missiles_to_spawn_in_gameplay = 0;
    private float total_missiles_to_spawn_at_start = 2;
    private void Start() {
        missile_spawner(total_missiles_to_spawn_at_start);    
    }
    private void Update() {
        if(Time.time>=timeStamp){
            missile_spawner(total_missiles_to_spawn_in_gameplay);
        }

        
    }

    private void missile_spawner(float n)
    {

        // Debug.Log("Unity is working properly");
        timeStamp = Time.time + delay;
        total_missiles_to_spawn_in_gameplay+=1;
        int i = 0;
        while (i < n)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            int rand = Random.Range(0, missiles.Length);
            Instantiate(missiles[rand], coordinate, Quaternion.identity);
            i++;
        }

    }

}
