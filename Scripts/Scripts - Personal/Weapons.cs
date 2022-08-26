using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
      //  if(GetComponent<isPlayer>())
         //   isPlayer = true;
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo >0 || infiniteAmmo == true)
            return true;
        }
        return false;
    }

    public void shoot()
    {
        //Cooldown
        lastShootTime = Time.time;
        curAmmo--;
        // Creating an instance of the bullet prefab at muzzles position and rotation
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        //Add velocity to projectile
        bullet.GetComponent <Rigidbody>().velocity = muzzle.forward * bulletSpeed;
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
