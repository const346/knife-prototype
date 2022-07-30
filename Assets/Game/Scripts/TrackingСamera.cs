using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Tracking—amera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, -3);

    private Camera usedCamera;

    private void Awake()
    {
        usedCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        var pos = target.transform.position + offset;
        usedCamera.transform.position = pos; 
    }
}
