using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTransform;
    public float offset = 0;
    public int DistanceFloor = 0;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.x += offset;
        temp.y = playerTransform.position.y + DistanceFloor;
        transform.position = temp;
    }
}
