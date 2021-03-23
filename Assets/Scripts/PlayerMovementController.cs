using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;

    [SerializeField] float xBorder;
    [SerializeField] float yBorder;

    private void FixedUpdate()
    {
        float movementSpeed = defaultMovementSpeed;

        // don't let player leave the screen
        StayWithinBorders();

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

    void StayWithinBorders()
    {        
        if (transform.position.x > xBorder) // Right border
            transform.position = new Vector3(xBorder, transform.position.y, transform.position.z);

        if (transform.position.x < -xBorder) // Left border
            transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);

        if (transform.position.y > yBorder) // Top border
            transform.position = new Vector3(transform.position.x, yBorder, transform.position.z);

        if (transform.position.y < -yBorder) // Bottom border
            transform.position = new Vector3(transform.position.x, -yBorder, transform.position.z);
    }
}
