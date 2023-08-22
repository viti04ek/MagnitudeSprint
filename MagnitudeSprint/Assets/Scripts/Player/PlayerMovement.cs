using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _prevTouchPos;
    private Vector3 _curTouchPos;
    public float MoveSpeed;

    private void Update()
    {
        DetectSwipe();
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
}
