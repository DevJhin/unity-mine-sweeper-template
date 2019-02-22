using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEffect : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float z;

    // Update is called once per frame
    void Update()
    {
        Vector3 pointerPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,z));
       // pointerPosition.y = 0;
        transform.position = pointerPosition;
    }
} 
