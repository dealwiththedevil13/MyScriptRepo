using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 50.0f;
    public float hInput; 
    public float vInput;

    public float xRange = 11.76f;
    public float yRange = 5.1f;

    public GameObject projectile;
    public Transform launcher;
    public Vector3 offset = new Vector3(0,1,0);

    // public float health;
 
    // Update is called once per frame
    void Update()
    {

     hInput = Input.GetAxisRaw("Horizontal");
     vInput = Input.GetAxisRaw("Vertical");
     
      transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
      transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);

//Create a wall on -x side
     if(transform.position.x < -xRange)
     {
         transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
     }
//create a wall on x side
     if(transform.position.x > xRange)
     {
         transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
     }

     if(transform.position.y > yRange)
     {
         transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
     }

     if(transform.position.y < -yRange)
     {
         transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
     }

    if(Input.GetKeyDown(KeyCode.Space))
{
    Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
}
    }
}
