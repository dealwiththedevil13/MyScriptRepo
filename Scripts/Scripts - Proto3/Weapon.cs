using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject bulletPrefab; (old code)
    public ObjectPool bulletPool; //<= New Code
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;

    private float lastShootTime;
    private bool isPlayer;

    // Set Audio source and sound to play
    public AudioClip shootSFX;
    private AudioSource audioSource;
    


    void Awake()
    {
        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<PlayerController>())
             isPlayer = true;

        audioSource = GetComponent<AudioSource>();
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
      {
        if(curAmmo > 0 || infiniteAmmo == true)
         return true;
      }
         return false;

    }

    public void Shoot()
    {
        //Cooldown
        lastShootTime = Time.time;
        curAmmo--;
        //creating an instance of the bullet prefab at muzzles position and rotation
       // GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); (old code)
        GameObject bullet = bulletPool.GetObject(); // <--(new code)
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
                
        //add velocity to projectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer)
        {
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }
        //Play Shoot sound effect
        audioSource.PlayOneShot(shootSFX);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
