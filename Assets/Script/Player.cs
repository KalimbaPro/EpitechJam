using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping = false;
    public bool isGrounded;

    public Transform leftFoot;
    public Transform rightFoot;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(leftFoot.position, rightFoot.position);

        float horizontalVelocity = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePlayer(horizontalVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
