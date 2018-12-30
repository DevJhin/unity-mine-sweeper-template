using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour {

    Camera cam;
    public LayerMask layerMask;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

}
