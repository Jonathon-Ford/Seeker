using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    private Camera thisCamera;
    private Func<Vector3> GetCameraFollowPosition;
    private Func<float> GetCameraZoom;

    //This setup function allows for the camera to be set to another character by passing a new follow positon
    public void Setup(Func<Vector3> GetCameraFollowPosition, Func<float> GetCameraZoom)
    {
        this.GetCameraFollowPosition = GetCameraFollowPosition;
        this.GetCameraZoom = GetCameraZoom;
    }

    //Sets up thisCamera to point at itself
    private void Start()
    {
        thisCamera = transform.GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Zoom();
    }

    private void Movement()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPosition();
        cameraFollowPosition.z = transform.position.z; //Makes it so the z position of the camera does not become the z psition of the focus
        // transform.position = Vector3.Lerp(transform.position, cameraFollowPosition, Time.deltaTime);  smoth transition
        transform.position = cameraFollowPosition;
    }

    private void Zoom()
    {
        float cameraZoom = GetCameraZoom();
        float cameraZoomDiff = cameraZoom - thisCamera.orthographicSize;

        thisCamera.orthographicSize += cameraZoomDiff * .002f;
    }

}
