using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;

    private bool _stop = false;


    private void Update()
    {
        if (!_stop)
            Rigidbody.velocity = Vector3.back * Speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeleteObstacle"))
            Destroy(gameObject);
    }


    public void Stop()
    {
        _stop = true;
        Rigidbody.velocity = Vector3.zero;
    }
}
