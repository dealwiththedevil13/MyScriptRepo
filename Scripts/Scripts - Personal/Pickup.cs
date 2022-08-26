using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
     //bobbing and rotation motion
    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;

    private Vector3 startPos;
    //get Audio for pickup
   public AudioClip pickupSFX;

   public GameObject pickupParticle;

   void Start()
   {
       startPos = transform.position;
   }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
         //Create the hit particle
             GameObject obj = Instantiate(pickupParticle, transform.position, Quaternion.identity);

    }
}
