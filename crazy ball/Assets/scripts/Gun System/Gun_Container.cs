using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gun_Container 
{
    public static Gun Pistol = new Gun(0.2f, 1, 0.0f, 12f, 1, "Pistol");
    public static Gun revolver = new Gun(0.4f, 2,0.4f, 14f, 2, "Revolver");
    public static Gun Shotgun = new Gun(0.55f, 6, 0.35f, 14f, 1, "Shotgun");
    

    
    
}
