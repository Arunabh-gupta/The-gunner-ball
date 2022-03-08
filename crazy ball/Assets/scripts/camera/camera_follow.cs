using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }


}
