using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_firing : MonoBehaviour
{
    public float recoil;
    private Gun gun; // the gun object with its features 
    Gun[] gun_list = { Gun_Container.Pistol, Gun_Container.Shotgun, Gun_Container.revolver }; // list of all the guns
    private bool readyTofire = true; // don't what's this is for😪😪. Might use in future 
    public GameObject bullet_prefab; // actual prefab for the bullet
    [SerializeField]
    private Transform Nozzle; // the point where the bullet will be instantiated

    //for adding a delay between firing of bullets
    private float timestamp = 0.0f;
    private float perShotDelay; // fireRate argument of gun object will given to this
    //for adding a delay between firing of bullets

    private void Start()
    {

        gun = gun_list[0]; // assigning the created gun object a gun from the Gun_Container class
        perShotDelay = gun.GetFireRate();


    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > timestamp)
        {
            Fire(gun);
        }
    }

    // firing of bullets function 
    private void Fire(Gun gun)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = mousePos - (Vector2)Nozzle.position;
        dir.Normalize();
        for (int i = 0; i < gun.GetBullets(); i++)
        {
            timestamp = Time.time + perShotDelay;
            GameObject bullet = Instantiate(bullet_prefab, Nozzle.position, Quaternion.identity);
            // smoke effect particle effect
            ParticleSystem smoke_effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().bullet_smoke, Nozzle.position, Quaternion.identity);
            smoke_effect.Play();
            // smoke effect particle effect
            float speed = gun.GetSpeed();
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-gun.GetSpread(), gun.GetSpread());
            bullet.GetComponent<Rigidbody2D>().AddForce((dir + pdir) * gun.GetSpeed(), ForceMode2D.Impulse);
            bullet.GetComponent<bullet>().damage = gun.GetDamage();
        }
    }
    // firing of bullets function
}
