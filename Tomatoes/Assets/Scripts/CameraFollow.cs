using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CameraScrollEvent: UnityEvent<float, float> { }

public class CameraZoomEvent: UnityEvent<float> { }

public class CameraFollow : MonoBehaviour
{
    private Camera myCamera;
    private Func<Vector3> GetCameraFollowPositionFunc;
    private Func<float> GetCameraZoomFunc;
    public float followSpeed = 0.7f;
    public float cameraZoomSpeed = 1f;
    public bool freeMovement;

    public Vector3 cameraFollowPosition;

    public static UnityEvent SwitchToFreeCamera;
    public static UnityEvent SwitchToFocusCamera;
    public static CameraScrollEvent ScrollCamera;
    public static CameraZoomEvent ZoomCamera;

    void SwitchToFreeCameraHandler()
    {
        SetCameraFollowPosition(cameraFollowPosition);
        freeMovement = true;
        Debug.Log("Switched to Free cam");
    }

    void SwitchToFocusCameraHandler()
    {
        //SetCameraFollowPosition(cameraFollowPosition);
        freeMovement = false;
        Debug.Log("Switched to Focus cam");
    }

    void ScrollCameraHandler(float x, float y)
    {        
        cameraFollowPosition += new Vector3(x, y);
        SwitchToFreeCamera.Invoke();
    }

    void ZoomCameraHandler(float z)
    {
        SetCameraZoom(z);        
    }


    public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }

    public void SetCameraFollowPosition(Vector3 pos)
    {
        SetCameraFollowFunc(() => pos);        
    }

    public void SetCameraFollowObject(Transform target)
    {
        SetCameraFollowFunc(() => target.position);
    }

    public void SetCameraFollowFunc(Func<Vector3> GetCamFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCamFollowPositionFunc;        
    }

    public void SetCameraZoom(float zoom)
    {
        SetCameraZoomFunc(() => zoom);
    }
    public void SetCameraZoomFunc(Func<float> GetCameraZoomFunc)
    {
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }


    private void HandleMovement()
    {        
            cameraFollowPosition = GetCameraFollowPositionFunc();
            cameraFollowPosition.z = transform.position.z;

            Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);
            float cameraMoveSpeed = 2f;

            transform.position = //Vector3.Lerp(cameraFollowPosition, transform.position, followSpeed);
                transform.position + cameraMoveDir * distance * followSpeed * Time.deltaTime;
        
    }

    private void HandleZoom()
    {
        float cameraZoom = GetCameraZoomFunc();

        float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;

        myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

        if (cameraZoomDifference > 0)
        {
            if (myCamera.orthographicSize > cameraZoom)
            {
                myCamera.orthographicSize = cameraZoom;
            }
        }
        else
        {
            if (myCamera.orthographicSize < cameraZoom)
            {
                myCamera.orthographicSize = cameraZoom;
            }
        }

    }
    private void Start()
    {
        myCamera = transform.GetComponent<Camera>();

        if (SwitchToFocusCamera == null)
        {
            SwitchToFocusCamera = new UnityEvent();
        }
        if (SwitchToFreeCamera == null)
        {
            SwitchToFreeCamera = new UnityEvent();
        }
        if (ScrollCamera == null)
        {
            ScrollCamera = new CameraScrollEvent();
        }
        if (ZoomCamera == null)
        {
            ZoomCamera = new CameraZoomEvent();
        }

        SwitchToFreeCamera.AddListener(SwitchToFreeCameraHandler);
        SwitchToFocusCamera.AddListener(SwitchToFocusCameraHandler);
        ScrollCamera.AddListener(ScrollCameraHandler);
        ZoomCamera.AddListener(ZoomCameraHandler);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleZoom();
    }
}
