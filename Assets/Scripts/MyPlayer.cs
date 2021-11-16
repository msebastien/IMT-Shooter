using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    private CharacterController controller;
    public float mouseSensibility = 50f;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // With Input Manager
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * mouseSensibility, Space.World);

        if (Input.GetKey(KeyCode.Z))
        {
            controller.Move(transform.forward * moveSpeed);
            //transform.Translate(transform.forward * moveSpeed, Space.World);
            //transform.Translate(new Vector3(0, 0, 1), Space.Self);
            //transform.Translate(Vector3.forward, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(-transform.forward * moveSpeed);
            //transform.Translate(-transform.forward * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            controller.Move(-transform.forward * moveSpeed);
            //transform.Translate(-transform.right * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(transform.right * moveSpeed);
            //transform.Translate(transform.right * moveSpeed, Space.World);
        }

        controller.Move(new Vector3(0, -9.81f, 0));
    }
}
