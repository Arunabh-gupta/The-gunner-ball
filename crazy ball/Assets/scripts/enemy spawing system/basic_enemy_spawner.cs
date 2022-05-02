using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_enemy_spawner : MonoBehaviour
{
    // list of enemies;
    [SerializeField] GameObject[] enemy_list;
    private float xmin = -20f, xmax = 20f, ymin = -10f, ymax = 10f;
    private int total_enemies_to_spawn_at_start = 6;
    private int total_enemies_to_spawn_in_gameplay = 0;
    private float radius = 4f;
    Vector2 coordinate;

    // timer
    private float timeStamp = 0.0f;
    private float delay_between_two_spawns = 10f;
    // timer 

    private void Awake()
    {
        enemy_spawner(total_enemies_to_spawn_at_start);
    }

    private void Update() {
        if(Time.time>=timeStamp){
            enemy_spawner(total_enemies_to_spawn_in_gameplay);
        }
    }
    private void enemy_spawner(float n)
    {

        // Debug.Log("Unity is working properly");
        timeStamp = Time.time + delay_between_two_spawns;
        total_enemies_to_spawn_in_gameplay+=1;
        int i = 0;
        while (i < n)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            int rand = Random.Range(0, enemy_list.Length);
            Instantiate(enemy_list[rand], coordinate, Quaternion.identity);
            i++;
        }

    }
}
