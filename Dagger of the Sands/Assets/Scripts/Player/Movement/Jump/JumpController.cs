using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class JumpController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] public Jump Jump;
    [SerializeField] public DoubleJump doubleJump;
    [SerializeField] PlayerController playerController;

    private bool canDoubleJump;
    [SerializeField] private bool isDaggerObtained;
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
            canDoubleJump = false;
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
            if (playerController.playerSpaceDetection.IsGrounded() || canDoubleJump)
            {
                playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x,
                    canDoubleJump ? playerController.doubleJump.doubleJumpForce : playerController.Jump.jumpForce);
                if (!canDoubleJump)
                {
                    playerController.anim.SetBool("isGrounded", true);
                    FindObjectOfType<AudioManager>().PlaySound("Jump");
                }
                else if (canDoubleJump)
                {
                    playerController.anim.SetTrigger(doubleJumpAnim);
                    count++;
                    FindObjectOfType<AudioManager>().PlaySound("DoubleJump");
                }


                playerController.anim.SetBool("Run", false);
                playerController.anim.SetBool("Idle", false);
                Debug.Log(canDoubleJump + "" + count);
                canDoubleJump = !canDoubleJump;
                Debug.Log(canDoubleJump + "" + count);
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
                playerController.rigidBody.velocity = new Vector2(playerController.rigidBody.velocity.x, playerController.Jump.jumpForce);


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

