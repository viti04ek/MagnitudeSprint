using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;

    public Animator Animator;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void Idle()
    {
        Animator.SetInteger("State", 0);
    }


    public void Run()
    {
        Animator.SetInteger("State", 1);
    }


    public void Fall()
    {
        Animator.SetInteger("State", 2);
    }


    public void Smash()
    {
        Animator.SetInteger("State", 3);
    }


    public void Push()
    {
        Animator.SetInteger("State", 4);
        Invoke("Run", 0.07f);
    }
}
