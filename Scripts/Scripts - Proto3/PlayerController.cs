using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]
    public float moveSpeed;        //movement speed in units per second
    public float jumpForce;         //force applied upwards
    
    public int curHp;
    public int maxHp;
    
    [Header("Mouse Look")]
    public float lookSensitivity;           //Mouse look sensitivity
    public float maxLookX;      //loewest down we can look
    public float minLookX;      //highest up we can look
    public float rotX;          //curent x rotation

    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent <Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get components
        camera = Camera.main;
        rb = GetComponent <Rigidbody>();

        //Initialize the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);

    }

    // Applies Damage to the player
    public void TakeDamage(int damage)
{
    curHp -= damage;

    if(curHp <= 0)
        Die();

    GameUI.instance.UpdateHealthBar(curHp, maxHp);
}
//If players health is reduced zero or below then run Die()
    void Die()
    {
        GameManager.instance.LoseGame();
    }
   

    void Move()
    {
        float x= Input.GetAxis("Horizontal") * moveSpeed;
        float z= Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x,rb.velocity.y, z);- Old code
        // Move direction relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;
    
        rb.velocity = dir;
        dir.y = rb.velocity.y;

    }

    void CamLook()
    {
        float y= Input.GetAxis("Mouse X") * lookSensitivity;
        rotX -= Input.GetAxis("Mouse Y") * lookSensitivity;
        
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up *y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            {
                // Add force to jump
               rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
    }
    
    public void GiveHealth(int amountToGive)
    {
            curHp =Mathf.Clamp(curHp + amountToGive, 0, maxHp);
            GameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo=Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo,weapon.maxAmmo);

    }

         void Update()
    {
        Move();
        CamLook();
        // fire button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            weapon.Shoot();
        }
          if (Input.GetButtonDown("Jump"))
             Jump();
            
        //Don't do anything if the game is paused
         if(GameManager.instance.gamePaused == true)
            return;
    }
}
