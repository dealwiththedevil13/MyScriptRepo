using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string pickupName;
    public int amount;

    public GameManager gameManger;

    void Update()
    {
        transform.Rotate(Vector3.back * 10 * Time.deltaTime);
    }

  void OnTriggerEnter2D(Collider2D other)
  {
      print("You Picked up a" + pickupName);
      gameManger.hasKey = true;
      Destroy(gameObject);
  }
}
