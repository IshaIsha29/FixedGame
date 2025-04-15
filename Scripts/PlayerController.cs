using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float tiltAmount = 5f; // Amount of tilt (rotation) applied based on velocity

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // Rotate the cube based on its velocity
        RotateBasedOnVelocity();
    }

    void RotateBasedOnVelocity()
    {
        // Calculate the rotation angle based on the bird's vertical velocity
        float angle = Mathf.Clamp(rb.linearVelocity.y * tiltAmount, -90, 45);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
