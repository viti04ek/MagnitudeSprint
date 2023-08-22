using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator Animator;
    public int Strength;

    public void Fall()
    {
        Animator.SetTrigger("Fall");
        Invoke("Destroy", 2f);
    }


    private void Destroy()
    {
        Destroy(gameObject);
    }
}
