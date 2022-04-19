using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tween_manager : MonoBehaviour
{
    
    [SerializeField] GameObject shotGun, MachineGun, HealthPill;
    
    private void Start() {
            LeanTween.rotateAround(shotGun,Vector3.forward,-360, 2f).setLoopClamp(); // rotation animation
            LeanTween.rotateAround(MachineGun,Vector3.forward,-360, 2f).setLoopClamp(); // rotation animation
            LeanTween.rotateAround(HealthPill,Vector3.forward,-360, 1f).setLoopClamp(); // rotation animation
    }
}
