using UnityEngine;

public class WallSlide : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Wall Jump")]
    [SerializeField] float yWallForce;
    [SerializeField] float xWallForce;
    [SerializeField] private float wallJumpCooldown;
    bool wallJumping;


    [Header("Wall slide")]
    [SerializeField] float checkRadius;
    [SerializeField] Transform frontCheck;
    [SerializeField] float wallSlideSpeed;
    [SerializeField] float rayDistance;
    [SerializeField] private LayerMask wallLayer;
    public bool isTouchingFront;
    public bool wallSliding;

    public bool IsWall()
      {
          RaycastHit2D raycastHit = Physics2D.BoxCast(playerController.boxCollider.bounds.center, playerController.boxCollider.bounds.size,
              0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
          return raycastHit.collider != null;
      } 


    private void Update()
    {
        if (!playerController.isGamePaused)
        {
            WallSlideMotion();
            WallJump();
        }
    }

    private void WallSlideMotion()
    {
        
        Debug.DrawRay(frontCheck.position, transform.TransformDirection(new Vector3(transform.localScale.x, 0, 0)) * rayDistance, Color.black);

        isTouchingFront = Physics2D.Raycast(frontCheck.position,
          transform.TransformDirection(new Vector3(transform.localScale.x, 0, 0)),
          rayDistance, wallLayer);

        if (isTouchingFront == true && playerController.playerSpaceDetection.IsGrounded() == false && playerController.playerInputScript.horizontalInput != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x,
                Mathf.Clamp(playerController.rigidBody.velocity.y, -wallSlideSpeed, float.MaxValue));

            playerController.anim.SetTrigger("Slide");
        }
    }

    private void WallJump()
    {
        if (playerController.playerInputScript.jumpInput && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpCooldown);
        }


        if (wallJumping == true)
        {
            playerController.rigidBody.velocity = new Vector2(xWallForce * -playerController.playerInputScript.horizontalInput, yWallForce);
        }
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}

