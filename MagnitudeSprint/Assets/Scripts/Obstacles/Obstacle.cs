using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;


    private void Update()
    {
        Rigidbody.velocity = Vector3.back * Speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeleteObstacle"))
            Destroy(gameObject);
    }
}
