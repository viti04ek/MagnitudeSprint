using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbell : MonoBehaviour
{
    public Rigidbody Rigidbody;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Obstacle>().enabled = false;
            Rigidbody.AddForce(Vector3.left * 1000);
            Invoke("DestroyMe", 2f);
        }
    }


    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
