using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float downwardForce;

    [Header("Animation")]
    public bool moving;
    public bool idle;

    [Header("VFX")]
    [SerializeField] private ParticleSystem dust;
    private bool flippedRight;
    private bool flippedLeft;

    [Header("SFX")]
    [SerializeField] AudioClip movementAudio;

    void Start()
    {
        // Debug.Log("Horizontal Movement Script");
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.isGamePaused)
                HorziontalMovement();
    }

    private void HorziontalMovement()
    {
        //Cache the horzionatl input. 
        playerController.playerInputScript.horizontalInput = Input.GetAxis("Horizontal");

        //Moves the player according to input.
        playerController.rigidBody.velocity = new Vector2(playerController.playerInputScript.horizontalInput * movementSpeed,
            playerController.rigidBody.velocity.y);

        //Play sound while moving.
        if (playerController.playerSpaceDetection.IsGrounded() && playerController.playerInputScript.horizontalInput != 0)
        {
            //FindObjectOfType<AudioManager>().PlaySound("Moving");
        }

        //flips player according to their direction. 
        if (playerController.playerInputScript.horizontalInput > 0.01f)
        {
            flippedRight = true;
            flippedLeft = false;
            transform.localScale = Vector3.one;
        }
        else if (playerController.playerInputScript.horizontalInput < -0.01f)
        {
            flippedLeft = true;
            flippedRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Dust effect
        if (flippedRight && playerController.playerSpaceDetection.IsGrounded() && playerController.playerInputScript.horizontalInput != 0)
        {
            CreateDust();
        }
        else if (flippedLeft && playerController.playerSpaceDetection.IsGrounded() && playerController.playerInputScript.horizontalInput != 0)
        {
            CreateDust();
        }

        //Player the running animation. 
            MotionBlendTree();      
        // playerController.anim.SetBool("isRunning", isMoving());

    }

    public void isMoving()
    {
        moving = playerController.playerSpaceDetection.IsGrounded() && playerController.playerInputScript.horizontalInput != 0;
    }

    public void isIdle()
    {
        idle = playerController.playerSpaceDetection.IsGrounded() && playerController.playerInputScript.horizontalInput == 0;
    }

    private void CreateDust()
    {
        dust.Play();
    }

    public void MovingAnimation()
    {
        playerController.anim.SetBool("Run", moving);
    }

    public void IdleAnimation()
    {
        playerController.anim.SetBool("Idle", idle);
    }

    public void MotionBlendTree()
    {
        if (playerController.playerSpaceDetection.IsGrounded())
            playerController.anim.SetFloat("xVelocity", playerController.rigidBody.velocity.x);
    }

    private void PlayLandingAudio()
    {
        bool isNotGrounded; 
        if (playerController.playerSpaceDetection.IsGrounded())
        {
            isNotGrounded = false;
        }
        else
        {
            isNotGrounded = true;
        }

        if (isNotGrounded)
        {
            FindObjectOfType<AudioManager>().PlaySound("Land");
        }
    }
}
