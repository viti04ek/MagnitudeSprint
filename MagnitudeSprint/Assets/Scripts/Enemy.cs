using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator Animator;
    public int Strength;
    public GameObject StrengthImg;


    public void Fall()
    {
        Destroy(StrengthImg);
        Animator.SetTrigger("Fall");
    }
}
