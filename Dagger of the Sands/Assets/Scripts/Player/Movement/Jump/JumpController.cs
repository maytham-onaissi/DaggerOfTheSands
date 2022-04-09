using System.Collections;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] public Jump Jump;
    [SerializeField] public DoubleJump doubleJump;
    [SerializeField] PlayerController playerController;

    [Header("General")]
    private bool canDoubleJump;
    [SerializeField] public bool isDaggerObtained;
    [SerializeField] public float jumpForce;
    [SerializeField] public float doubleJumpForce;
    private string doubleJumpAnim = "DoubleJump";
    private string JumpAnim = "Jump";
    int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.playerSpaceDetection.IsGrounded() && !playerController.playerInputScript.jumpInput)
        {
            playerController.anim.SetBool("isGrounded", false);
            //playerController.anim.SetBool(doubleJumpAnim, false);
            //canDoubleJump = false;
        }

        if (!playerController.isGamePaused)
        {
            if (!isDaggerObtained)
            {
                beforeDaggerJumpAbility();
            }
            else
            {
                AfterDaggerJumpAbility();
            }

        }



        //playerController.anim.SetBool("Falling", playerController.playerSpaceDetection.isFallingDown() && playerController.WallSlide.wallSliding == false);
    }

    public IEnumerator DaggerAcquire()
    {
        isDaggerObtained = true;

        playerController.notifyText.text = "Dagger acquired; Press Space after jumping to jump a second time";

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

    public void DaggerAcquired()
    {
        StartCoroutine(DaggerAcquire());
    }

    private void AfterDaggerJumpAbility()
    {
        if (playerController.playerInputScript.jumpInput)
        {
            playerController.anim.SetBool("Run", false);
            playerController.anim.SetBool("Idle", false);

            if (playerController.playerSpaceDetection.IsGrounded())
            {
                playerController.rigidBody.AddForce(Vector2.up * jumpForce);
                playerController.anim.SetBool("isGrounded", true);
                FindObjectOfType<AudioManager>().PlaySound("Jump");
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    playerController.rigidBody.AddForce(Vector2.up * doubleJumpForce);
                    playerController.anim.SetTrigger(doubleJumpAnim);
                    FindObjectOfType<AudioManager>().PlaySound("DoubleJump");
                }
            }

        }

        if (playerController.playerInputScript.notjumpingInput && playerController.rigidBody.velocity.y > 0f)
        {
            playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x,
                playerController.rigidBody.velocity.y * 0.5f);

        }
    }


    private void beforeDaggerJumpAbility()
    {


        if (playerController.playerInputScript.jumpInput)
        {
            if (playerController.playerSpaceDetection.IsGrounded())
            {
                playerController.rigidBody.AddForce(Vector2.up * jumpForce);

                playerController.anim.SetBool("isGrounded", true);

                FindObjectOfType<AudioManager>().PlaySound("Jump");

                playerController.anim.SetBool("Run", false);

                playerController.anim.SetBool("Idle", false);
            }

        }

        if (playerController.playerInputScript.notjumpingInput && playerController.rigidBody.velocity.y > 0f)
        {
            playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x,
                playerController.rigidBody.velocity.y * 0.5f);

        }
    }

}

