using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _prevTouchPos;
    private Vector3 _curTouchPos;
    public float MoveSpeed;
    public bool Move = true;


    private void Start()
    {
        enabled = false;
    }


    private void Update()
    {
        if (Move)
        {
            DetectSwipe();
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
        }
        else
        {
            StopMove();
        }
    }

    private void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _curTouchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _prevTouchPos = _curTouchPos;
            _curTouchPos = Input.mousePosition;

            transform.Translate(Vector3.right * (_curTouchPos.x - _prevTouchPos.x) * MoveSpeed * Time.deltaTime);
        }
    }


    private void StopMove()
    {
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, 0.1f);
    }
}
