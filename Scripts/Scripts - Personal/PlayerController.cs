using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float rotationSpeed;
    public float jumpForce;
    private float horizontalInput;
    private float forwardInput;
     private Rigidbody rb;

    public AudioClip deathSFX;
    private AudioSource audioSource;

    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    //Destroy player on contact with enemy
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            audioSource.PlayOneShot(deathSFX);
           Destroy(gameObject);
           GameManager.instance.LoseGame();
        }
    }

    public void GiveHealth(int amuntToGive)
{

}
    // Update is called once per frame
    void Update()
    {
        //Turning based on Horizontal and Vertical Iput
        horizontalInput= Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, forwardInput);
        movementDirection.Normalize();

        //movement
        transform.Translate(movementDirection * speed* Time.deltaTime, Space.World);

        if(movementDirection !=Vector3.zero)
        {
           // transform.forward = movementDirection;
           Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

           transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
       // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       // transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Doesn't do anything when the game is paused
        if(GameManager.instance.gamePaused == true)
        return;
    }

   

}
