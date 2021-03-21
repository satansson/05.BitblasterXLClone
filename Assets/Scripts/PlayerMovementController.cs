using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;

    private void FixedUpdate()
    {
        float movementSpeed = defaultMovementSpeed;
        // boost
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed += extraAccelerationSpeed;
        }
        // slow down
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementSpeed *= breakingFactor;
        }

        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        // turn left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * defaultTurnSpeed * Time.deltaTime);
        }
        // turn right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * defaultTurnSpeed * Time.deltaTime);
        }
    }



}
