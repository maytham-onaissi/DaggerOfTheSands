using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Double Jump")]
    [SerializeField] private int extraJumps;
    [SerializeField] public int keyUpAmount;
    [SerializeField] public float doubleJumpForce;
    public bool isDoubleJump;
    public bool doubleJumped;
    public bool fallingDoubleJumped;
    public int extraJumpsCounter;
    public int keyUpCounter;

    [Header("Animation")]
    const string doubleJump = "DoubleJump";

    private void Start()
    {
        // Debug.Log("Double Jump Script");
        extraJumpsCounter = extraJumps;
        keyUpCounter = keyUpAmount;
    }

    private void Update()
    {
       /* if (playerController.playerSpaceDetection.IsGrounded())
        {
            extraJumpsCounter = extraJumps;
            keyUpCounter = keyUpAmount;
            fallingDoubleJumped = true;
            isDoubleJump = true;
        }*/

       // DoubleJumpAbility(doubleJumpForce);
    }

    public void DoubleJumpAbility(float _jumpForce)
    {
        //Allow the player to double jump.
       // if ( playerController.playerInputScript.doubleJumpInput && isDoubleJump)
        //{
            Debug.Log("double jump");
            playerController.rigidBody.velocity = Vector2.up * _jumpForce;
            extraJumpsCounter--;
            doubleJumped = true;
            playerController.Jump.jumped = false;
            //DoubleJumpAnimation();

           // playerController.animationController.ChangeAnimationState(doubleJump);

            //playerController.anim.SetBool("DoubleJump", true);
            // }

            //Allow the player to double jump while falling.
            /*if (playerController.playerSpaceDetection.isFallingDown() && extraJumpsCounter > 1)
            {
                doubleJumped = true;
                extraJumpsCounter--;
                playerController.Jump.jumped = false;
                playerController.rigidBody.velocity = Vector2.up * _jumpForce;
                playerController.anim.SetTrigger("Jump");
            }

            /*if (playerController.playerInputScript.notDoubleJumpingInput && extraJumpsCounter < 1 && keyUpCounter <= 1)
            {
                isDoubleJump = false;
                doubleJumped = false;
            }*/
        }

         void FallingDoubleJump()
        {

            Debug.Log("falling double jump");


            /*doubleJumped = true;
             extraJumpsCounter--;
             playerController.Jump.jumped = false;
             playerController.rigidBody.velocity = Vector2.up * _jumpForce;
             playerController.anim.SetTrigger("Jump");*/
        }
    } 
//}
