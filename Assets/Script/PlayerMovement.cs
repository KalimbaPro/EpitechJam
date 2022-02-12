using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    public bool isGrounded;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public Transform leftFoot;
    public Transform rightFoot;
    public LayerMask CollisionLayer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            StatsTracker.instance.addJump(1);
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(leftFoot.position, rightFoot.position, CollisionLayer);
        MovePlayer(horizontalMovement);
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

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}