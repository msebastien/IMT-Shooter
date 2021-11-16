using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public float mouseSensibility = 50f;
    public float moveSpeed = 1f;

    private Vector3 oldPos = Vector3.zero;
    private Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();

        //oldPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        // Without Input Manager
        // Moving mouse along X-Axis rotates camera along Y-Axis (up) in World
        // transform.Rotate(new Vector3(0, Input.mousePosition.x - oldPos.x, 0) * mouseSensibility, Space.World);
        // Moving mouse along Y-Axis rotates camera along X-Axis (up) in Camera's local transform
        // transform.Rotate(new Vector3(oldPos.y - Input.mousePosition.y, 0, 0) * mouseSensibility, Space.Self);
        

        // With Input Manager
        //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * mouseSensibility, Space.World);
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * mouseSensibility, Space.Self);

        //oldPos = Input.mousePosition;

        /*if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(transform.forward * moveSpeed, Space.World);
            //transform.Translate(new Vector3(0, 0, 1), Space.Self);
            //transform.Translate(Vector3.forward, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-transform.right * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * moveSpeed, Space.World);
        }*/

        //Debug.Log("Position souris : " + Input.mousePosition);
    }
}
