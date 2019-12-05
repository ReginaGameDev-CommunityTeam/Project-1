using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    public CameraFollow camFollow;
    public Transform targetTransform;

    public float zoom;
    public float zoomAmount;
    public float zoomMin;
    public float zoomMax;
    public float scrollAmount;
    public float scrollEdgeSize;

    public static UnityEvent SwitchToFreeCamera;
    public static UnityEvent SwitchToFocusCamera;

    private void Start()
    {
        camFollow.Setup(() => targetTransform.position, () => zoom);
        camFollow.SetCameraFollowPosition(targetTransform.position);
        camFollow.SetCameraFollowObject(targetTransform);
        camFollow.SetCameraZoom(100);
    }

    void HandleManualMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            CameraFollow.ScrollCamera.Invoke(scrollAmount * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            CameraFollow.ScrollCamera.Invoke(-1 * scrollAmount * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            CameraFollow.ScrollCamera.Invoke(0, scrollAmount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CameraFollow.ScrollCamera.Invoke(0, -1 * scrollAmount * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1))
        {
            camFollow.SetCameraFollowPosition(targetTransform.position);
            CameraFollow.SwitchToFocusCamera.Invoke();
        }
    }

    void HandleEdgeScrolling()
    {
        if (Input.mousePosition.x > Screen.width - scrollEdgeSize)
        {
            CameraFollow.ScrollCamera.Invoke(scrollAmount * Time.deltaTime, 0);
        }
        if (Input.mousePosition.x < scrollEdgeSize)
        {
            CameraFollow.ScrollCamera.Invoke(-1 * scrollAmount * Time.deltaTime, 0);
        }
        if (Input.mousePosition.y > Screen.height - scrollEdgeSize)
        {
            CameraFollow.ScrollCamera.Invoke(0, scrollAmount * Time.deltaTime);
        }
        if (Input.mousePosition.y < scrollEdgeSize)
        {
            CameraFollow.ScrollCamera.Invoke(0, -1 * scrollAmount * Time.deltaTime);
        }
    }

    void HandleZoom()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            ZoomIn();
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            ZoomOut();
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            ZoomIn();
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            ZoomOut();
        }

        CameraFollow.ZoomCamera.Invoke(zoom);
    }
    private void Update()
    {
        HandleManualMovement();
        HandleEdgeScrolling();

        HandleZoom();

    }

    private void ZoomIn()
    {
        zoom -= zoomAmount * Time.deltaTime ;
        if (zoom < zoomMin) zoom = zoomMin;

    }
    private void ZoomOut()
    {
        zoom += zoomAmount * Time.deltaTime;
        if (zoom > zoomMax) zoom = zoomMax;
    }
}
