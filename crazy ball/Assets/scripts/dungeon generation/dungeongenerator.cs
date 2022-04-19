using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeongenerator : MonoBehaviour
{
    GameObject random_room;
    Transform[] spawn_points;
    private void Start() {
        for(int i=0; i<random_room.transform.childCount; i++){
            spawn_points[i] = random_room.transform.GetChild(i); 
            Debug.Log(spawn_points[i]);
        }

    }
}
