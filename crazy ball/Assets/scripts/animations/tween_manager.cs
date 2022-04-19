using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tween_manager : MonoBehaviour
{
    [SerializeField] GameObject force_shield;

    
    private void Start() {
        // force_shield = GameObject.FindGameObjectWithTag("Shield");
        // LeanTween.rotateAround(force_shield,Vector3.forward,-3600, 10f).setLoopClamp();
    }
}
