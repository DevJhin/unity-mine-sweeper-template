using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    [Header("General")]
    public bool allowMovement;
    public bool allowRotation;
    public bool allowZoom;

    [Header("Movement Settings")]
    public float xMin;
    public float xMax;

    public float zMin;
    public float zMax;

    public float moveSpeed;

    [Header("Zoom Settings")]
    public float zoomMin;
    public float zoomMax;

    public float zoomSpeed;


    // Update is called once per frame
    void Update()
    {       
        float xDelta = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        float yDelta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float zDelta = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;

        Vector3 targetPos = transform.position + new Vector3(xDelta, -yDelta, zDelta) * Time.deltaTime;

        targetPos.x = Mathf.Clamp(targetPos.x, xMin, xMax);
        targetPos.y = Mathf.Clamp(targetPos.y, zoomMin, zoomMax);
        targetPos.z = Mathf.Clamp(targetPos.z, zMin, zMax);

        transform.position = targetPos;
    }

    IEnumerator CameraShakeEffect()
    {


        yield return null;
    }
}
