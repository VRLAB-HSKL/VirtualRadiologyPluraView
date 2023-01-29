using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCube : MonoBehaviour
{
	public float moveSpeed = 5;
    PlayerControls controls;
    Vector3 move;
    Vector3 rotate;

    private void Awake()
    {
        controls = new PlayerControls();



        controls.PlayerMovement.Movement.performed += cntxt => move = cntxt.ReadValue<Vector3>();
        controls.PlayerMovement.Movement.canceled += cntxt => move = Vector3.zero;

        controls.PlayerMovement.Rotation.performed += cntxt => rotate = cntxt.ReadValue<Vector3>();
        controls.PlayerMovement.Rotation.canceled += cntxt => rotate = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 m = new Vector3(move.x * 5, 0, move.y * 5);
        // Debug.Log(m);
        // GetComponent<Transform>().Translate(m * Time.deltaTime);
        // transform.Translate(m * Time.deltaTime);
        // GetComponent<Rigidbody>().velocity = m;

        // transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

		var trans = new Vector3(move.x, move.y, move.z);
		var newPos = transform.position + trans;

		transform.position = Vector3.MoveTowards(
			transform.position,
			newPos,
			moveSpeed * Time.deltaTime * trans.magnitude
		);


        transform.Rotate(Vector3.up * rotate.y, Space.World);
        transform.Rotate(Vector3.forward * rotate.z, Space.World);
        transform.Rotate(Vector3.right * rotate.x, Space.World);
    }

    void OnEnable(){
        controls.PlayerMovement.Enable();
    }

    void OnDisable(){
        controls.PlayerMovement.Disable();
    }

    private void OnResetObject()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);

    }
}
