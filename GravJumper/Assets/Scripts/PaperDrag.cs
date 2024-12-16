using UnityEngine;
using System.Collections.Generic;

public class MouseDrag : MonoBehaviour
{
    Rigidbody rb;
    private float distanceFromCamera;
    private float dragSpeed = 10f;
    private float range = 8f;
    public static bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        UpdateDistanceFromCamera();
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= range)
        {
            isDragging = true;
            UpdateDistanceFromCamera();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 objectRotation = Camera.main.transform.rotation.eulerAngles;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);

            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction = (objPosition - transform.position);

            rb.linearVelocity = direction * dragSpeed;

            rb.transform.rotation = Quaternion.Euler(objectRotation);
            
        }

    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void UpdateDistanceFromCamera()
    {
        Collider col = GetComponent<Collider>();
        float objectSize = col.bounds.extents.magnitude;
        distanceFromCamera = 5f;
    }

}