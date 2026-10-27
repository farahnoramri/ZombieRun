using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform target;
    void Update()
    {
        Vector3 targetPosition = new Vector3(
        target.position.x,
        transform.position.y,
        transform.position.z
        );

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
} 