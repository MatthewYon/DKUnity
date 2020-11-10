using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] public GameObject target;
    [SerializeField] public int z = 10;
    [SerializeField] public int x = 12;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 goalPos = target.transform.position;
        goalPos.y = transform.position.y;
        goalPos.z -= z;
        goalPos.x += x;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}