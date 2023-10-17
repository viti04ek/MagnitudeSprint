using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : MonoBehaviour
{
    public bool IsCoin;
    public float Speed;

    private GameObject _target;
    private bool _fly = false;


    private void Start()
    {
        if (IsCoin)
            _target = GameObject.Find("CoinCount");
        else
            _target = GameObject.Find("PlayerStrength");
    }


    private void Update()
    {
        if (_fly)
        {
            Vector3 targetPos = _target.transform.position;
            targetPos.z = 5f;
            transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(targetPos), Speed * Time.deltaTime);
        }
    }


    public void Fly()
    {
        GetComponent<Obstacle>().Stop();
        GetComponent<Obstacle>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        _fly = true;
        Invoke("Die", 0.5f);
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}
