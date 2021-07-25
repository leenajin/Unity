using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;

    Transform cameraTransform;
    Vector3 offset;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = playerTransform.position - cameraTransform.position;
    }

    private void LateUpdate()
    {
        cameraTransform.position = Vector3.Lerp(cameraTransform.position,
            playerTransform.position - offset,
            Time.deltaTime);
    }
}
