using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public float speed = 10.5f;
public float turnspeed;
  
    // Start is called before the first frame update
    void Start()
    {
     turnspeed =11.2f;

        print(speed);

        print(turnspeed);   
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * speed * Time.deltaTime);  
    }
}
