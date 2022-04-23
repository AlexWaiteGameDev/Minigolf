using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // VARS
    public float MovementSpeed = 3.0f;
    public float Sensitivy  = 2.0f;

    private Vector2 MouseAbsolute;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Confined;

        // Camera starting direction
        MouseAbsolute.x = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // KEYBOARD CONTROLS *****************

        
        Vector3 Forward = transform.forward; // Forward

        Forward.y = 0.0f;

        Forward.Normalize();

        Forward = Forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        
        Vector3 Right = transform.right * Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime; // Right

        // Final Transform
        transform.position += Forward + Right;

        // MOUSE CONTROLS ***********************
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta *= Sensitivy;

        MouseAbsolute += mouseDelta;

        MouseAbsolute.y = Mathf.Clamp(MouseAbsolute.y, -89.9f, 89.9f);

        transform.localRotation = Quaternion.AngleAxis(-MouseAbsolute.y, Vector3.right); // OR // MouseAbsolute.y, Vector3.left
    
        Quaternion yRotation = Quaternion.AngleAxis(MouseAbsolute.x, transform.InverseTransformDirection(Vector3.up)); // Inverse clamps the rotation axis to prevent wobble

        transform.localRotation *= yRotation;
    }
}

// Sloped Camera Tips, Raycast down, move camera 1 unit above that
