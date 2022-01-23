using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float downwardForce;
    float horizontalInput;

    [Header("General")]
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider; 
    private Animator anim;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Jump")]
    [SerializeField] private float jumpPower;

    //Sound effects
    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound; 
    [SerializeField] private AudioClip meleeSound; 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //General method for movement. 
    private void Movement()
    {
        HorziontalMovement();
        Jump(jumpPower);
    }

    private void HorziontalMovement()
    {
        //Cach the horzionatl input. 
        horizontalInput = Input.GetAxis("Horizontal");

        //Moves the player according to input.
        rigidBody.velocity = new Vector2(horizontalInput * movementSpeed, rigidBody.velocity.y);

        //flips player according to their direction. 
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Player the running animation. 
        anim.SetBool("isRunning", isMoving());

    }

    //Jumping method.
    private void Jump(float _jumpPower)
    {
        //Check if the player pressed "space" and is not on the ground. 
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, _jumpPower);
            //Play the jump animation. 
            anim.SetTrigger("Jump");
        }
    }

    //Checks if the player is on the ground by casting a box collider that starts from the center of the character to the ground. 
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    //Checks if the player is moving and not jumping. 
    private bool isMoving()
    {
        return isGrounded() && horizontalInput != 0;
    }
}
