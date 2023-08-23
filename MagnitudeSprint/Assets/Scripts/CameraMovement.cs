using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;


    private void Update()
    {
        if (Target.position.x < -1.6f)
        {
            Vector3 target = new Vector3(-1f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
        }
        else if (Target.position.x > 1.6f)
        {
            Vector3 target = new Vector3(1f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
        }
        else
        {
            Vector3 target = new Vector3(0f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
        }
    }
}
