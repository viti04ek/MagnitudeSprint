using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbell : MonoBehaviour
{
    public Rigidbody Rigidbody;


    public void Slap()
    {
        Obstacle obstacle = GetComponent<Obstacle>();
        if (obstacle != null)
            obstacle.enabled = false;

        Rigidbody.AddForce(Vector3.left * 1000);
        Invoke("DestroyMe", 2f);
    }


    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
