﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.1f, 1.0f)]
    public float SmoothFactor = 1.0f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 5.0f;

    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (RotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
             
                _cameraOffset = camTurnAngle * _cameraOffset;
            }
            

        }
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        if (LookAtPlayer || RotateAroundPlayer) 
            transform.LookAt(new Vector3(PlayerTransform.position.x, PlayerTransform.position.y+2, PlayerTransform.position.z));
    }
}