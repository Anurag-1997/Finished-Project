using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float currentZoom;
    public float value;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;
    public float currentRotateValue;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * value);
        transform.RotateAround(target.position, Vector3.up, currentRotateValue);
    }
    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentRotateValue -= Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

    }
}
