using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObstacle : MonoBehaviour
{
    public static FinishObstacle Instance;

    public float Speed;
    public Rigidbody Rigidbody;

    public bool Stop = false;
    private bool _once = true;


    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if (!Stop)
        {
            Move();
            _once = true;
        }
        else
        {
            if (_once)
                Move();
            _once = false;
        }
    }


    private void Move()
    {
        Rigidbody.velocity = Vector3.back * Speed;
        foreach (Transform child in transform)
        {
            Rigidbody childRb = child.GetComponent<Rigidbody>();
            if (childRb != null)
            {
                childRb.velocity = Rigidbody.velocity;
            }
        }
    }
}
