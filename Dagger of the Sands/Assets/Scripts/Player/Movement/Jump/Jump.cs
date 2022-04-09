using UnityEngine;

public class Jump : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;

    [Header("Jump")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float jumpTime;
    public bool isJumping;
    public bool jump;
    public bool jumped;
    public float jumpTimeCounter;

    [Header("SFX")]
    [SerializeField] AudioClip jumpAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Jump Script");
    }

    // Update is called once per frame
    void Update()
    {
        /* if (playerController.playerSpaceDetection.IsGrounded())
         {
             isJumping = true;
             jumpTimeCounter = jumpTime; 
             jumped = false;
             jump = true;
             playerController.anim.SetBool("Jump", false);
         }

         //JumpAbility(jumpForce);
     }

     public void JumpAbility(float _jumpPower)
     {

         //Check if the player pressed "space" and is not on the ground. 

         if (playerController.playerInputScript.stilljumpingInput && isJumping == true)
         {
             if (jumpTimeCounter > 0)
             {
                 playerController.rigidBody.velocity = Vector2.up * _jumpPower;
                 FindObjectOfType<AudioManager>().PlaySound("Jump");
                 JumpAnimation();
                 jumpTimeCounter -= Time.deltaTime;
             }
             else
             {
                 isJumping = false; 
                 playerController.anim.SetBool("Jump", false);

             }

         }

         if (playerController.playerInputScript.notjumpingInput)
         {
             isJumping = false;
             playerController.anim.SetBool("Jump", false);
         }

     }




         public void JumpAnimation()
     {
         playerController.anim.SetBool("Jump", true);
     }
 }
 */
    }
}
